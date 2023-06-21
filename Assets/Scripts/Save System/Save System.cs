using Assets.Scripts.Save_System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SaveSystem : MonoBehaviour
{
    private List<ISaveSystem> SaveObject = new List<ISaveSystem>();

    private static SaveSystem instance;
    private static object syncRoot = new Object();

    private SaveSystem() { SaveObject = new List<ISaveSystem>(); }  

    public static SaveSystem getInstance()
    {
        if (instance == null)
        {
            lock (syncRoot)
            {
                if (instance == null)
                    instance = new();                
            }
        }
        return instance;
    }

    public static void AddSaveObject(ISaveSystem Object) => getInstance().SaveObject.Add(Object);

    public static void SaveGame()
    {
        foreach (var i in getInstance().SaveObject)
        {
            if (PlayerPrefs.HasKey(i.GetKey()))
                PlayerPrefs.DeleteKey(i.GetKey());

            PlayerPrefs.SetString(i.GetKey(), i.GetSaveData());
        }
    }

    public static void LoadGame()
    {
        foreach (var i in getInstance().SaveObject)        
            if (PlayerPrefs.HasKey(i.GetKey()))
                i.LoadData(PlayerPrefs.GetString(i.GetKey()));

    }

    public void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance == this)
        { // Ёкземпл€р объекта уже существует на сцене
            Destroy(gameObject); // ”дал€ем объект
        }

        //DontDestroyOnLoad(gameObject);
    }

}
