using UnityEngine;
using System.Collections;
using Assets.Scripts.Menu;
using Assets.Scripts.Player.Inventory;

public class InventoryMenu : Menu
{
    [SerializeField] private InventoryScroller Scroller;


    public override Menu GoBack()
    {
        throw new System.NotImplementedException();
    }

    public override void HitsObjectMenu(RaycastHit[] Hit)
    {
        
    }

    public override void MoveObject(Vector3 DeltaPositon, Vector3 Position)
    {
        InventorySystem.GetInstance().TouchPosition = Position;
        if (InventorySystem.GetInstance().IsMoveItem)
        {
            //Debug.Log("Двигаем");
            InventorySystem.GetInstance().CurrentItemMove.Move(DeltaPositon);
        }
        

    }

    public override void ScrollMenu(float DeltaPosition)
    {
        Scroller.Scroll(DeltaPosition);
    }
}
