using Assets.Scripts.Save_System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Save_System
{
    public sealed class SaveSystem : MonoBehaviour
    {        
        private List<ISaveSystem> SaveObject = new();

        private static SaveSystem instance;

        private static object syncRoot = new Object();
        private SaveSystem() { SaveObject = new(); }
        public static SaveSystem GetInstance()
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

        public static void AddSaveObject(ISaveSystem Object) => GetInstance().SaveObject.Add(Object);

        public static void SaveGame()
        {
            foreach (var i in GetInstance().SaveObject)
            {
                if (PlayerPrefs.HasKey(i.GetKey()))
                    PlayerPrefs.DeleteKey(i.GetKey());

                PlayerPrefs.SetString(i.GetKey(), i.GetSaveData());
            }
        }

        public static void LoadGame()
        {
            foreach (var i in GetInstance().SaveObject)
                if (PlayerPrefs.HasKey(i.GetKey()))
                {
                    i.LoadData(PlayerPrefs.GetString(i.GetKey()));

                    #if UNITY_EDITOR


                    # endif
                }
                else
                {
                    i.BaseLoadData();

                    #if UNITY_EDITOR

                    #endif
                }


        }

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance == this)
            { // Ёкземпл€р объекта уже существует на сцене
                Destroy(gameObject); // ”дал€ем объект
            }
        }
        public void Start()
        {
            LoadGame(); 
        }

        public void OnApplicationQuit()
        {
            SaveGame();
        }

    }
}
