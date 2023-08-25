using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Save_System;
using System.Text;

namespace Assets.Scripts.Player.Inventory
{
    public class Inventory : MonoBehaviour, ISaveSystem
    {
        private const string SaveKey = "Inventory";

        static private Inventory instance;

        public delegate void AddInvenotrySpase();

        public event AddInvenotrySpase AddInventorySpaseEvent; 

        public int CountElement_X { get => countElement_X; private set => countElement_X = value; }

        public int CountElement_Y { get => countElement_Y; private set => countElement_Y = value; }
        
        public int MaxElement_X { get => maxElement_X; private set => maxElement_X = value; }
        
        public int MaxElement_Y { get => maxElement_Y; private set => maxElement_Y = value; }
        
        private List<List<InventoryItem>> Items;

        [SerializeField]
        private List<Transform> ParentsUI;

        [SerializeField]
        private int maxElement_Y;

        [SerializeField]
        private int maxElement_X;

        [SerializeField]
        private int countElement_X;

        [SerializeField]
        private int countElement_Y;

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(this);

            Items = new List<List<InventoryItem>>();
            {
                int j = 0;
                for (int i = 0; i < ParentsUI.Count; i++)
                {
                    ParentsUI[i].gameObject.GetComponent<InventoryBackgroundItemMover>().InitPosition(j, i / MaxElement_X);
                    j = (j + 1) % 4;
                }
            }

            for (int i = 0; i < maxElement_Y; i++)
            {
                Items.Add(new List<InventoryItem>(CountElement_X));
                for (int j = 0; j < CountElement_X; j++)
                {
                    Items[i].Add(new InventoryItem());
                    Items[i][j].Active = true;

                    if (i >= countElement_Y)
                    {
                        GetParent(j, i).gameObject.SetActive(false);
                        Items[i][j].Active = false;
                    }
                }
            }
        }

        public void BaseLoadData()
        {

            AddInventorySpaseEvent.Invoke();
        }

        public string GetKey()
        {
            return SaveKey;
        }

        public string GetSaveData()
        {
            throw new System.Exception();
        }

        public void LoadData(string val)
        {
            AddInventorySpaseEvent.Invoke();
        }

        public void Swap(int x1, int y1, int x2, int y2)
        {
            InventoryItem obj = Items[y1][x1];
            Items[y1][x1] = Items[y2][x2];
            Items[y2][x2] = obj;

        }

        [ContextMenu("Add Inventory Plase")]
        public void AddInventoryPlase()
        {
            if (instance.countElement_Y < instance.MaxElement_Y)
            {
                for (int i = 0; i < maxElement_X; i++)
                {
                    GetParent(i, instance.countElement_Y).gameObject.SetActive(true);
                    Items[instance.countElement_Y][i].Active = true;
                }
                instance.countElement_Y++;
            }

            AddInventorySpaseEvent.Invoke();
        }

        public Transform GetParent(int x, int y)
        {
            if (y > 0)
                return ParentsUI[CountElement_X * y + x];
            else
                return ParentsUI[x];
        }

        public static Inventory GetInstance()
        {
            if (instance == null)
                instance = new();

            return instance;
        }

        public bool IsFull()
        {
            foreach (var j in Items)
                foreach (var i in j)
                    if (i.Empty())
                        return false;
            return true;
        }

        public bool IsFull(out (int?, int?) IndexEmpty)
        {
            try
            {
                IndexEmpty = new(null, null);

                for (int i = 0; i < Items.Count; i++)
                    for (int j = 0; j < Items[i].Count; j++)

                        if (Items[i][j].Empty())
                        {
                            IndexEmpty.Item1 = i;
                            IndexEmpty.Item2 = j;
                            return false;
                        }
                return true;
            }
            catch
            {
                throw new System.Exception("Is Full Exp");

            }
        }

        public InventoryItem GetItem(int x, int y)
        {
            return instance.Items[y][x];
        }

        public bool Add(IInventoryObject item)
        {
            if (IsFull(out (int?, int?) IndexEmpty))
            {                
                return false;
            }
            else
            {
                if (IndexEmpty.Item1 != null && IndexEmpty.Item2 != null)
                {
                    Debug.Log("Создали объект");
                    int X = IndexEmpty.Item1.Value;
                    int Y = IndexEmpty.Item2.Value;
                    //print($"{IndexEmpty.Item1.Value} {IndexEmpty.Item2.Value}");

                    InventoryItem inventoryItem = new InventoryItem
                                            (
                                            item.CreateUIGameObejct(GetParent(Y, X)),
                                            item
                                            );
                    //inventoryItem.UI.GetComponent<InventoryItemView>().InitPosition(Y, X);

                    Items[X][Y] =
                        inventoryItem;
                }

                Debug.Log(Print());
                return true;
            }
        }

        public string Print()
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < Items.Count; i++)
            {
                for (int j = 0; j < Items[i].Count; j++)
                {
                    if (Items[i][j].Empty())
                        s.Append("[ - ]");
                    else
                        s.Append("[ + ]");
                }
                s.Append("\n");
            }

            return s.ToString();
        }
    }

    public class InventoryItem
    {
        public GameObject UI { get; private set; }
        public IInventoryObject Item { get; private set; }
        public bool Active { get; set; }

        public InventoryItem()
        {
            UI = null;
            Item = null;
        }

        public InventoryItem(GameObject uI, IInventoryObject item)
        {
            UI = uI;
            Item = item;
            Active = false;
        }

        public InventoryItem(GameObject uI, IInventoryObject item, bool active) : this(uI, item)
        {
            Active = active;
        }

        public bool Empty()
        {
            if (UI == null && Item == null && Active)
                return true;
            else
                return false;
        }
    }
}