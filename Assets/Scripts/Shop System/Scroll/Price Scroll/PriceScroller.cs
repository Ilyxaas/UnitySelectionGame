using Assets.Scripts.Shop_System;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PriceScroller : MonoBehaviour
{
    [SerializeField] private Scrollbar _Slider;
    [SerializeField] private RectTransform RectPrice;

    private float _MaxValue;

    private float _MinValue = 0;

    private float _CurrentValue = 0;

    private float _SliderPrevValue = 0;

    private float _DeltaValue = 0;

    private float _CurentMaxValue = 0;

    private void Awake()
    {
        _MaxValue = -1 * RectPrice.rect.height / 2;
        _Slider.gameObject.SetActive(false);
    }

    private void Start()
    {
        ShopSystem.GetInstance().View.DrawShopItemEvent += View_DrawShopItemEvent;
    }

    private void View_DrawShopItemEvent(float SizePriceY)
    {
        Debug.Log(SizePriceY + " " + _MaxValue);
        if (SizePriceY < _MaxValue)
        {
            _Slider.gameObject.SetActive(true);
            float value = Math.Abs(SizePriceY - _MaxValue);
            _DeltaValue = value;
            MoveToDefault();
        }
        
    }

    private void MoveToDefault()
    {
        _Slider.value = 0;
    }

    public void Slider_OnValueChange()
    {
        float MoveValue = (_Slider.value - _SliderPrevValue) * _DeltaValue;
        _SliderPrevValue = _Slider.value;
        Scroll(MoveValue);
    }

    public void Scroll(float value)
    {

        if (_CurrentValue + value > _MaxValue && _CurrentValue + value < _MinValue)
        {
            _CurrentValue -= value;
            RectPrice.Translate(new Vector3(0, -1 * value, 0));
        }
    }
}
