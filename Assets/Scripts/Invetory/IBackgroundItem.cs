using System;
using Assets.Scripts.Menu;

namespace Assets.Scripts.Player.Inventory
{
    public interface IBackgroundItem
    {
        public Borders GetRectBackgroundItem();

        public (int, int) GetBackgroundItemPosition();

        public InventoryBackgroundItemMover GetCurrentBackGroundItem();

    }
}