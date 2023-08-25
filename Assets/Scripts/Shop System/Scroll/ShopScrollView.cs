using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Shop_System
{

    public class ShopScrollView : MonoBehaviour
    {
        [SerializeField] private int Index;
        [SerializeField] private Image Image;
        [SerializeField] private Button Button;

        public void ChangeCategory()
        {
            ShopSystem.GetInstance().Category.SetCategory(Index);
        }

        public void ReInitialize(ShopScrollItem item)
        {
            Image.sprite = item.Icon;            
        }
    }
}
