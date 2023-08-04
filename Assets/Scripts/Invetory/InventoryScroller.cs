using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Player.Inventory
{
    public class InventoryScroller : MonoBehaviour
    {
        [SerializeField] private Transform TitlesParent;

        [SerializeField] private RectTransform RectFouter;

        [SerializeField] private Scrollbar Scrollbar;

        [SerializeField] private static float TitleSize = 250;
        
        private float MaxValue;

        private float StandartYValueTitlesParent;

        private float FouterValue;

        private float MinValue = 0;

        private float CurrentValue = 0;

        private void OnValidate()
        {
            if (MaxValue < MinValue)
                MaxValue = MinValue + 1;

            if (MinValue > MaxValue)
                MinValue = MaxValue - 1;
        }

        private void Awake()
        {
            StandartYValueTitlesParent = TitlesParent.transform.position.y;
            CurrentValue = MinValue;
            Inventory.GetInstance().AddInventorySpaseEvent += InventoryScroller_AddInventorySpaseEvent;
            FouterValue = RectFouter.rect.yMax + RectFouter.position.y;
            ScrollBar_OnValueChange();
        }

        private void InventoryScroller_AddInventorySpaseEvent()
        {
            
            var obj = Inventory.GetInstance().GetParent(0, Inventory.GetInstance().CountElement_Y - 1).GetComponent<RectTransform>();
            float value = StandartYValueTitlesParent + obj.localPosition.y + obj.rect.yMin;

            if (value < FouterValue)
            {
                MaxValue = FouterValue - value + 25;
            }
        }


        public void ScrollBar_OnValueChange()
        {

        }


        public void Scroll(float value)
        {
            if (CurrentValue + value < MaxValue && CurrentValue + value > MinValue)
            {
                CurrentValue += value;
                TitlesParent.Translate(new Vector3(0, value, 0));
            }
        }
    }
}
