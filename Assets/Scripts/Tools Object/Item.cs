using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Player.Inventory;
using UnityEngine;


public enum Rarity
{
    Standart = 0,
    Rare  = 1,
    Mystical = 2,
    Legendary = 3,
    Unique = 4,    
}

public abstract class Item : ScriptableObject
{
    [SerializeField]    
    private Sprite icon;

    [SerializeField]
    protected string description;

    [SerializeField]
    protected string names;

    [SerializeField]
    protected Rarity RarityType;    

    public Sprite Icon { get => icon; protected set => icon = value; }

    public string Name { get => names; protected set => names = value; }

    public string Description { get => description; protected set => description = value; }

    public Rarity rarityType { get => RarityType; private set => RarityType = value; }

    


}


