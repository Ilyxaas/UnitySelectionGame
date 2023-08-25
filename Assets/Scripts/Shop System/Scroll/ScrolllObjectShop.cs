using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Struct;
using UnityEngine.Events;

namespace Assets.Scripts.Shop_System
{
    public class ScrolllObjectShop : MonoBehaviour
    {
        [SerializeField] private List<ShopScrollItem> ScrollObjects;

        [SerializeField] private List<ShopScrollView> ScrollViewObjects;

        private Struct.LinkedList<ShopScrollItem> ScrollList;
        public ShopScrollItem CurrentCategory { get; private set; }

        [SerializeField] private Color32 ColorInitCategory;

        public void Awake()
        {
            ScrollList = new Struct.LinkedList<ShopScrollItem>();

            for (int i = 0; i < ScrollObjects.Count; i++)
                ScrollList.Add(ScrollObjects[i]);
            Redraw();
        }

        private void Redraw()
        {
            for (int i = 0; i < ScrollViewObjects.Count; i++)
                ScrollViewObjects[i].ReInitialize(ScrollList[i].value);
        }

        public void ScrollLeft()
        {
            ScrollList.MoveLeft();
            Redraw();
        }

        public void ScrollRight()
        {
            ScrollList.MoveRight();
            Redraw();
        }

        public void SetCategory(int IndexCategory)
        {
            CurrentCategory = ScrollList[IndexCategory].value;
            Debug.Log("New Category " + CurrentCategory.Category);
        }
                
    }
}
