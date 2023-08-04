using System;
using UnityEngine;

namespace Assets.Scripts.Player.Inventory
{


    public interface IInventoryObject
    {
        public Sprite GetIcon();

        public string GetName();

        public GameObject CreateUIGameObejct(Transform Parent);            

    }
}
