using UnityEditor;
using UnityEngine;


namespace Assets.Scripts.Player.Inventory
{
    public interface IShovel
    {

    }

    [CreateAssetMenu(menuName = "Item/Shovel")]
    public class Shovel : Tools, IShovel, ILogInConsoleSystem
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
