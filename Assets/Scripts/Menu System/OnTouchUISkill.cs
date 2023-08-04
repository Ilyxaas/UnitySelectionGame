using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Menu
{
    public class OnTouchUISkill : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {    
        public void OnPointerEnter(PointerEventData eventData)
        {
            MenuManager.GetInstanse().SetUITouch(true);            
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            MenuManager.GetInstanse().SetUITouch(false);            
        }
    }
}
