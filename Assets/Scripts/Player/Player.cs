using Assets.Scripts.Save_System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;


public class Player : MonoBehaviour, ISaveSystem
{
    private const string PlayerKey = "PlayerSaveObject";
    private static Player instance;
    private static object syncRoot = new Object();
    
    private int Money { set; get; }
    private int RealValue { set; get; }

    private Player() 
    {
        
    }

    public static Player getInstance()
    {
        if (instance != null)
        {
            lock (syncRoot)
            {
                if (instance == null)
                    instance = new();
            }
        }
        return instance;
    }

    private void Start()
    {
        ISaveSystem.ConnectionSaveSystem(this);
        if (instance == null)
            instance = this;
        else if (instance == this)
        { // Ёкземпл€р объекта уже существует на сцене
            Destroy(gameObject); // ”дал€ем объект
        }

        DontDestroyOnLoad(gameObject);
    }

    string ISaveSystem.GetKey()
    {
        return PlayerKey;
    }

    string ISaveSystem.GetSaveData()
    {
        StringBuilder result = new StringBuilder();
        result.Append(Money);
        result.Append(" ");
        result.Append(RealValue);
        return result.ToString();
    }

    void ISaveSystem.LoadData(string val)
    {
        string[] data = val.Split(' ');
        Money = int.Parse(data[0]);
        RealValue = int.Parse(data[1]);
    }

   
}
