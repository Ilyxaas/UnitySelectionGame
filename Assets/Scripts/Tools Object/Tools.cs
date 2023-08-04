using UnityEngine;
using System.Collections;
using Assets.Scripts.Items.Tools_Rare;
using Assets.Scripts.Items.Rare;
using UnityEngine.UI;

namespace Assets.Scripts.Player.Inventory
{
    public enum ToolsType
    {
        Shovel = 0,
        Watering_can = 1,
        pruner = 2,
        Sprayer = 3        
    }

    public enum Format
    {
        Mini = 0,
        Standart = 1,
        Large = 2
    }

    
    public abstract class Tools : Item , IInventoryObject
    {
        [SerializeField]
        private bool Unloved;

        [SerializeField]
        private int MaxEndurance;

        [SerializeField]
        protected int CurrentEndurance;

        [SerializeField]
        private Format formatTools;

        public int Maxendurance { get => MaxEndurance; protected set => MaxEndurance = value; }

        protected ToolsRare Rare { get; private set; }

        public bool unloved { get => Unloved; protected set => Unloved = value; }

        public int Currentendurance { get => CurrentEndurance; protected set => CurrentEndurance = value; }

        public Format FormatTools { get => formatTools; protected set => formatTools = value; }

        //public abstract void Action();

        private void OnValidate()
        {
            switch (RarityType)
            {
                case Rarity.Standart:
                    {
                        Rare = new Standart();
                        break;
                    }
                case Rarity.Rare:
                    {
                        Rare = new Rare();
                        break;
                    }
                case Rarity.Mystical:
                    {
                        Rare = new Mystical();
                        break;
                    }
                case Rarity.Legendary:
                    {
                        Rare = new Legendary();
                        break;
                    }
                case Rarity.Unique:
                    {
                        Rare = new Unique();
                        break;
                    }
            }

        }

        public Sprite GetIcon()
        {
            return Icon;
        }

        public string GetName()
        {
            return Name;
        }
        
        GameObject IInventoryObject.CreateUIGameObejct(Transform Parent)
        {
            Debug.Log(Parent.name);
            GameObject result =
                 Instantiate(InventorySystem.GetInstance().UITypeToolsIcon, Parent);
            result.GetComponentInChildren<Image>().sprite = Icon;
            return result;
        }
    }

}
