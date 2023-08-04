using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.Player.Inventory
{
    public class InventoryItemView : MonoBehaviour
    {
        [SerializeField]
        private int x;
        [SerializeField]
        private int y;

        public int X { get => x; private set => x = value; }
        public int Y { get => y; private set => y = value; }

        public void InitPosition(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
