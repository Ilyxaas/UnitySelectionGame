using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.Shop_System
{
    public delegate void DrawShopItem(float SizePriceY);
    public class ShopView : MonoBehaviour
    {
        public event DrawShopItem DrawShopItemEvent;

        [SerializeField] private GameObject ShopViewPrefab;
        [SerializeField] private Transform ViewParent;
        private List<ShopViewItem> ViewPrice = new List<ShopViewItem>();

        public void ClearViewItem()
        {
            foreach (var item in ViewPrice)
            {
                Destroy(item);
            }
            ViewPrice = new List<ShopViewItem>();
        }


        public void Instantiate(ITradedDonateValue obj)
        {
            GameObject instance = Instantiate(ShopViewPrefab, ViewParent);
            ShopViewItem item = instance.GetComponent<ShopViewItem>();
            item.Initialize(obj);
            ViewPrice.Add(item);
            MoveItem(instance);

            RectTransform rect = ViewPrice[ViewPrice.Count - 1].gameObject.GetComponent<RectTransform>();

            DrawShopItemEvent.Invoke
                (
                rect.localPosition.y - rect.rect.height / 2
                ); 
        }

        public void Instantiate(ITradedCoin obj)
        {
            GameObject instance = Instantiate(ShopViewPrefab, ViewParent);
            ShopViewItem item = instance.GetComponent<ShopViewItem>();
            item.Initialize(obj);
            ViewPrice.Add(item);
            MoveItem(instance);
        }

        private void MoveItem(GameObject obj)
        {
            RectTransform rect = obj.GetComponent<RectTransform>();            
            rect.localPosition = new Vector3
                (rect.localPosition.x,
                rect.localPosition.y - rect.rect.size.y * (ViewPrice.Count - 1),
                rect.localPosition.z);
            
        }
    }
}
