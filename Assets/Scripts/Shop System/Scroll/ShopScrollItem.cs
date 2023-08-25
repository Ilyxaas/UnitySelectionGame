using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Shop_System
{

    [CreateAssetMenu(menuName = "Shop/Category")]
    public class ShopScrollItem : ScriptableObject
    {
        [SerializeField] private Sprite icon;        
        [SerializeField] private ShopCategory category;

        public Sprite Icon { get => icon; private set => icon = value; }
        public ShopCategory Category { get => category; private set => category = value; }
    }
}
