using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Menu
{
    public class OnTouchUISkill : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {        
        public bool IsTouch { get; private set; } = false;
        public void OnPointerEnter(PointerEventData eventData)
        {
            IsTouch = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            IsTouch = false;
        }

        


    }
}
