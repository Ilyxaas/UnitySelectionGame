using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Player.Inventory;
using UnityEngine.UI;

namespace Assets.Scripts.Shop_System
{
    
    public interface ITradedCoin : ITraded
    {
        public int PriceCoin { get; }
    }

    public interface ITradedDonateValue : ITraded
    {
        public int PriceDonate { get; }
    }

    public interface ITraded
    {
        public Sprite GetImage();

        public string GetNameItem();

        public ShopCategory GetCategory();

        public void Buy();

        public Type GetTypeObject();

        public Rarity GetRare();
    }
}
