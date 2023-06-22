using Assets.Scripts.Player.Level;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_0 : BaseLevel
{   
    public const int Level = 0;
    private const int NecessaryXPValue = 50;
    public Level_0(int CurentXp = 0)
    {
        CurentXpValue = CurentXp;
        Start();
    }
    public override int GetLevel()
    {
        return Level; 
    }

    public override BaseLevel AddXp(int value)
    {
        return BaseAddXp(value, NecessaryXPValue, out int superfluous) ? new Level_1(superfluous) : this;
    }

    public override void Start()
    {
        
    }

}
