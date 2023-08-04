using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Assets.Scripts.Player.Inventory;

namespace Assets.Scripts.Player.Inventory
{


    public class InventoryItemMover : MonoBehaviour,
    IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
    {
        private int SiblingIndex;
        private RectTransform Rect => GetComponent<RectTransform>();
        public Vector3 StartPosition { get; private set; }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("Нажали");
            try
            {                
                StartPosition = Rect.position;
                InventorySystem.GetInstance().SetStartBackgrounItem
                    (
                    gameObject.transform.parent.gameObject.GetComponent<InventoryBackgroundItemMover>()
                    );
                InventorySystem.GetInstance().SetStartMovePosition(Rect.position);
                InventorySystem.GetInstance().SetCurrentMoveItem(this);
                InventorySystem.GetInstance().SetGoBack(true);
                SiblingIndex = transform.parent.GetSiblingIndex();
                transform.parent.SetAsLastSibling();                

                Debug.Log($"Start Pos = {InventorySystem.GetInstance().StartBackItem.X} {InventorySystem.GetInstance().StartBackItem.Y}");
            }
            catch
            {
                throw new UnityException("On pointer Down");
            }
            
        }

        public void Move(Vector3 DeltaPos)
        {
            Debug.Log("Объект движется");
            Rect.transform.Translate(DeltaPos);
        }

        public void OnPointerUp(PointerEventData eventData)
        {    
            
            transform.parent.SetSiblingIndex(SiblingIndex);

            Debug.Log(InventorySystem.GetInstance().StartBackItem);
            Debug.Log(InventorySystem.GetInstance().CurrentBackItem);

            InventorySystem.GetInstance().InventorySwap
                   (
                    InventorySystem.GetInstance().StartBackItem.X, InventorySystem.GetInstance().StartBackItem.Y,
                    InventorySystem.GetInstance().CurrentBackItem.X, InventorySystem.GetInstance().CurrentBackItem.Y
                   );
            
            InventorySystem.GetInstance().DelCurrentMoveItem();
            InventorySystem.GetInstance().DelBackgrounItem();            
        }

        

        public void OnPointerMove(PointerEventData eventData)
        {
            Debug.Log("Двигаем");
            InventorySystem.GetInstance().CurrentBackGroundItem();
        }
    }
}
