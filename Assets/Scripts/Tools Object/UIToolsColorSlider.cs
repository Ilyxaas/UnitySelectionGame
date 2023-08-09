using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts.Player.Inventory
{
    public class UIToolsColorSlider : MonoBehaviour
    {
        [SerializeField] private Color MaxEnduranceColor;
        [SerializeField] private Color MinEnduranceColor;

        [SerializeField] private Slider Slider;

        [SerializeField] private Image FillImage;


        public void UpdateColorSliderValue(int MaxEndurance, int CurrentEndurance)
        {
            Slider.maxValue = MaxEndurance;
            Slider.value = CurrentEndurance;
            ColorInit();
        }

        public void ColorInit()
        {
            FillImage.color = Color.Lerp(MaxEnduranceColor, MinEnduranceColor, 1 - Slider.value / Slider.maxValue);
        }
    }
}
