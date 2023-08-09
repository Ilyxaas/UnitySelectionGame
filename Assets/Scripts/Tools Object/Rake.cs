using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player.Inventory
{
    [CreateAssetMenu(menuName = "Item/Rake")]
    public class Rake : Tools, ILogInConsoleSystem
    {
        [ContextMenu("Add To Inventory")]
        public void AddToInventory()
        {
            if (Application.IsPlaying(this))
            {
                ILogInConsoleSystem.ConsoleMessage($"Object {Name} Add to Inventory");

                Inventory.GetInstance().Add(Instantiate(this));
            }
        }
    }
}
