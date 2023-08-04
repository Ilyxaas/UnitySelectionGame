using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Assets.Scripts.Player.Inventory;
using Assets.Scripts.Menu;

namespace Assets.Scripts.Player.Inventory
{

    public class InventoryBackgroundItemMover : MonoBehaviour, IBackgroundItem
    {
        private RectTransform rect => GetComponent<RectTransform>();

        [SerializeField]
        private int x;
        [SerializeField]
        private int y;

        public int X { get => x; private set => x = value; }
        public int Y { get => y; private set => y = value; }       

        private void Start()
        {
            InventorySystem.GetInstance().AddBackGroundItems(this);
        }

        public void InitPosition(int x, int y)
        {
            X = x;
            Y = y;
        }        

        public Borders GetRectBackgroundItem()
        {
            var Rects = rect.rect;
            Vector2 pos = rect.position;

            Borders b = new Borders(
               new Vector2(Rects.xMax + pos.x, Rects.yMax + pos.y),
               new Vector2(Rects.xMin + pos.x, Rects.yMax + pos.y),
               new Vector2(Rects.xMin + pos.x, Rects.yMin + pos.y),
               new Vector2(Rects.xMax + pos.x, Rects.yMin + pos.y)
               );
            
            return b;
        }

        public (int, int) GetBackgroundItemPosition() => (Y, X);        

        public InventoryBackgroundItemMover GetCurrentBackGroundItem() => this;
        
    }
}
