using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Shop_System
{

    public class Shop : MonoBehaviour
    {
        [SerializeField] private Price PriceObject_Coin;

        [SerializeField] private Price PriceObect_Donat;

        private void Awake()
        {
            PriceObect_Donat.ReInitialize();
            PriceObject_Coin.ReInitialize();
        }

        public List<ITradedDonateValue> Price_Donat
        { 
            get 
            {
                PriceObect_Donat.GetPrice(out List<ITradedDonateValue> obj);
                return obj;
            }
        }
        public List<ITradedCoin> Price_Coin
        {
            get
            {
                PriceObject_Coin.GetPrice(out List<ITradedCoin> obj);
                return obj;
            }
        }

    }
}