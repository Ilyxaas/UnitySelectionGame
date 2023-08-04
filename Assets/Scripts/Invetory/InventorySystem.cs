using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Player.Inventory
{

    public class InventorySystem : MonoBehaviour
    {
        private static InventorySystem instance;

        public InventoryItemMover CurrentItemMove { get; private set; }

        public bool IsMoveItem { get; private set; }

        public Vector2 StartMovePosition { get; private set; }

        public bool IsBack { get; private set; }

        public GameObject UITypeStandartIcon { get => uITypeStandartIcon; private set => uITypeStandartIcon = value; }        

        public GameObject UITypeToolsIcon { get => uITypeToolsIcon; private set => uITypeToolsIcon = value; }

        public InventoryBackgroundItemMover CurrentBackItem { get; private set; }

        public InventoryBackgroundItemMover StartBackItem { get; private set; }

        List<IBackgroundItem> BackGroundItems = new List<IBackgroundItem>();

        public Vector2 TouchPosition { get; set; }

        [SerializeField]
        private GameObject uITypeToolsIcon;
        [SerializeField]
        private GameObject uITypeStandartIcon;        

        public static InventorySystem GetInstance()
        {
            if (instance == null)
                instance = new();

            return instance;
        }

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(this);
        }

        public void AddBackGroundItems(IBackgroundItem value)
        {
            instance.BackGroundItems.Add(value);
        }

        public void InventorySwap(int x1, int y1, int x2, int y2)
        {
            print($"{x1} {y1} {x2} {y2}");
            if (x1 == x2 && y1 == y2)
            {
                instance.CurrentItemMove.transform.position = instance.StartMovePosition;
            }
            else
            {
                if (Inventory.GetInstance().GetItem(x2, y2).Empty())
                {
                    instance.CurrentItemMove.gameObject.transform.SetParent(Inventory.GetInstance().GetParent(x2, y2));
                    instance.CurrentItemMove.gameObject.GetComponent<RectTransform>().localPosition = Vector3.zero;                    
                    Inventory.GetInstance().Swap(x1, y1, x2, y2);
                }
                else
                {               
                    instance.CurrentItemMove.gameObject.transform.SetParent(Inventory.GetInstance().GetParent(x2, y2));
                    instance.CurrentItemMove.gameObject.GetComponent<RectTransform>().localPosition = Vector3.zero;
                    Inventory.GetInstance().GetParent(x2, y2).GetChild(0).SetParent(Inventory.GetInstance().GetParent(x1, y1));
                    Inventory.GetInstance().GetParent(x1, y1).GetChild(0).GetComponent<RectTransform>().localPosition = Vector3.zero;
                    Inventory.GetInstance().Swap(x1, y1, x2, y2);
                }
            }

            Debug.Log(Inventory.GetInstance().Print());

        }



        public void CurrentBackGroundItem()
        {
            
            foreach (var i in BackGroundItems)
            {
                if (i.GetRectBackgroundItem().PointInBorders(TouchPosition))
                {
                    CurrentBackItem = i.GetCurrentBackGroundItem();
                    Debug.Log(CurrentBackItem.name);
                    return;
                }
            }
            Debug.Log("Ненайден");
        }

        public void SetCurrentMoveItem(InventoryItemMover item)
        {
            instance.CurrentItemMove = item;
            instance.IsMoveItem = true;
        }

        public void DelCurrentMoveItem()
        {            
            instance.CurrentItemMove = null;
            instance.IsMoveItem = false;
        }

        public void SetBackgrounItem(InventoryBackgroundItemMover item)
        {
            instance.CurrentBackItem = item;
        }

        public void DelBackgrounItem()
        {
            instance.CurrentBackItem = null;
        }

        public void SetStartBackgrounItem(InventoryBackgroundItemMover item)
        {
            instance.StartBackItem = item;
        }

        public void DelStartBackgrounItem()
        {
            instance.StartBackItem = null;
        }

        public void SetStartMovePosition(Vector2 Position)
        {
            StartMovePosition = Position;
        }

        public void SetGoBack(bool value)
        {
            IsBack = value;
        }

        

        
    }
}
