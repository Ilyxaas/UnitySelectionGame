using Assets.Scripts.Player.Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Shop_System
{
    public enum ShopCategory 
    {
        Pruner = 0,
        Rake = 1,
        Shovel = 2,
        Sprayer = 3,
        WateringCan = 4    
    }

    public class ShopSystem : MonoBehaviour
    {
        static private ShopSystem instance;
        public ScrolllObjectShop Category { get => category; private set => category = value; }
        public ShopView View { get => view; private set => view = value; }
        public Shop CurrentShop { get => currentShop; private set => currentShop = value; }

        [SerializeField] private ShopView view;
        [SerializeField] private ScrolllObjectShop category;
        [SerializeField] private Shop currentShop;

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(this);
        }

        private void Start()
        {
            StartCoroutine(DrawCoroutine());
        }

        IEnumerator DrawCoroutine()
        {
            yield return new WaitForSeconds(1);
            DrawListShop();
        }

        public static ShopSystem GetInstance() => instance;

        public void DrawListShop()
        {
            View.ClearViewItem();
            Debug.Log(CurrentShop.Price_Donat.Count);
            foreach (var item in CurrentShop.Price_Donat)
            {
                if (Category.CurrentCategory == null || (int)item.GetCategory() == (int)Category.CurrentCategory.Category)
                {
                    View.Instantiate(item);
                }
            }

            foreach (var item in CurrentShop.Price_Coin)
            {
                if (Category.CurrentCategory == null || (int)item.GetCategory() == (int)Category.CurrentCategory.Category)
                {
                    View.Instantiate(item);
                }
            }
        }

    }
}
