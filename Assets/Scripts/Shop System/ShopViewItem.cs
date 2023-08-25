using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Assets.Scripts.Shop_System
{
    public class ShopViewItem : MonoBehaviour
    {
        [SerializeField] private Image _Icon;

        [SerializeField] private TMP_Text _TMPName;
        [SerializeField] private TMP_Text _TMPPrice;
        [SerializeField] private TMP_Text _TMPCategory;
        [SerializeField] private TMP_Text _TMPRare;

        public bool Initialize(ITradedCoin coinInit)
        {
            try
            {
                _Icon.sprite = coinInit.GetImage();
                _TMPName.text = coinInit.GetNameItem();
                _TMPPrice.text = coinInit.PriceCoin.ToString();
                _TMPCategory.text = coinInit.GetCategory().ToString();
                _TMPRare.text = coinInit.GetRare().ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Initialize(ITradedDonateValue coinInit)
        {
            try
            {
                _Icon.sprite = coinInit.GetImage();
                _TMPName.text = coinInit.GetNameItem();
                _TMPPrice.text = coinInit.PriceDonate.ToString();
                _TMPCategory.text = coinInit.GetCategory().ToString();
                _TMPRare.text = coinInit.GetRare().ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
