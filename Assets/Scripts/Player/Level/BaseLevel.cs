using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BaseLevel 
{
    int XpLevel { get; }
    public abstract void Start();

    public abstract void GetXp();

}
