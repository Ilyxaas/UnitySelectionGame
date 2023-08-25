using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Shop_System
{
    [CreateAssetMenu(menuName = "Shop/Price Object")]
    public class Price : ScriptableObject
    {
        private enum PriceType { Coin = 0, Donat = 1 }

        [SerializeField] private PriceType _PriceType;
        [SerializeField] private List<ScriptableObject> _PriceObject;

        private List<ITradedDonateValue> _DonatPrice = new List<ITradedDonateValue>();
        private List<ITradedCoin> _CoinPrice = new List<ITradedCoin>();

        private void Initialize()
        {            
            switch (_PriceType)
            {
                case PriceType.Coin:
                    {
                        foreach (var item in _PriceObject)
                        {
                            if (item is ITradedCoin CoinItem)
                            {
                                _CoinPrice.Add(CoinItem);
                            }
                            else
                            {
                                throw new Exception($"None Convert to {typeof(ITradedCoin)}");
                            }
                        }
                        break;
                    }
                case PriceType.Donat:
                    {
                        foreach (var item in _PriceObject)
                        {
                            if (item is ITradedDonateValue CoinItem)
                            {
                                _DonatPrice.Add(CoinItem);
                            }
                            else
                            {
                                throw new Exception($"None Convert to {typeof(ITradedDonateValue)}");
                            }
                        }
                        break;
                    }
            }
        }

        public bool GetPrice(out List<ITradedCoin> Price)
        {            
            switch (_PriceType)
            {
                    case PriceType.Coin: { Price = _CoinPrice; return true; }

                    case PriceType.Donat: { Price = null; return false; }                        
            }
            Price = null;
            return false;
        }

        public bool GetPrice(out List<ITradedDonateValue> Price)
        {
            switch (_PriceType)
            {
                case PriceType.Coin: { Price = null; return false; }

                case PriceType.Donat: { Price = _DonatPrice; return true; }
            }
            Price = null;
            return false;
        }

        public void ReInitialize()
        {
            _DonatPrice = new List<ITradedDonateValue>();
            _CoinPrice = new List<ITradedCoin>();
            Initialize();
        }
    }
}