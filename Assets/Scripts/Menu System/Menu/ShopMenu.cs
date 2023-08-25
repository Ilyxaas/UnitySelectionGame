using Assets.Scripts.Menu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : Menu
{
    [SerializeField] private PriceScroller Scroller;
    public override Menu GoBack()
    {
        throw new System.NotImplementedException();
    }

    public override void HitsObjectMenu(RaycastHit[] Hit)
    {
        
    }

    public override void MoveObject(Vector3 DeltaPositon, Vector3 Position)
    {
       
    }

    public override void ScrollMenu(float DeltaPosition)
    {
        Scroller.Scroll(DeltaPosition);
    }
}
