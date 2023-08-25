using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Shop_System;
using UnityEngine.UI;
using System;

namespace Assets.Scripts.Player.Inventory
{
    [CreateAssetMenu(menuName = "Item/Sprayer")]
    public class Sprayer : Tools, ITradedCoin, ITradedDonateValue
    {
        [SerializeField] private int priceCoin;

        [SerializeField] private int priceDonat;
        public int PriceCoin { get => priceCoin; }
        public int PriceDonate { get => priceDonat; }

        [ContextMenu("Add To Inventory")]
        public void AddToInventory()
        {
            if (Application.IsPlaying(this))
            {
                ILogInConsoleSystem.ConsoleMessage($"Object {Name} Add to Inventory");

                Inventory.GetInstance().Add(Instantiate(this));
            }
        }

        public void Buy()
        {
            
        }

        public Sprite GetImage() => Icon;

        public string GetNameItem() => Name;        

        public Type GetTypeObject() => GetType();

        public ShopCategory GetCategory() => ShopCategory.Sprayer;

        public Rarity GetRare() => RarityType;

    }
}
