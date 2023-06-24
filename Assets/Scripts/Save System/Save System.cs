using Assets.Scripts.Save_System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Assets.Scripts.Save_System
{
    public sealed class SaveSystem : MonoBehaviour, ILogInConsoleSystem
    {
        private static float WaitSecond = 1;

        private List<ISaveSystem> SaveObject = new();
        private static SaveSystem instance;        
        private SaveSystem() { SaveObject = new(); }

        public static SaveSystem GetInstance()
        {            
            if (instance == null)
            {                
                instance = new SaveSystem();
            }

            return instance;
        }

        public static void AddSaveObject(ISaveSystem Object) {
            
            print("Connect " + Object + " " + GetInstance()); GetInstance().SaveObject.Add(Object);
        }

        public static int CountConnection() => GetInstance().SaveObject.Count;

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
                        ILogInConsoleSystem.ConsoleMessage($"{i.GetTypeClass()} + Load from file ");
                    #endif
                }
                else
                {
                    i.BaseLoadData();

                    #if UNITY_EDITOR
                        ILogInConsoleSystem.ConsoleMessage($"{i.GetTypeClass()} + Base Load ");
                    #endif

                }


        }

        private void Awake()
        {            
            if (instance == null)
                instance = this;
            else if (instance != null)
            {
                print("Destroy");
                Destroy(this);
            }

            print("SaveSystem Log" + instance);
        }

        public void Start()
        {
            print("LoadGame");
            StartCoroutine(WaitForStartLoad());
        }

        public void OnApplicationQuit()
        {
            SaveGame();
        }

        IEnumerator WaitForStartLoad()
        {
            yield return new WaitForSeconds(WaitSecond);

            #if UNITY_EDITOR
                ILogInConsoleSystem.ConsoleMessage($" Load Game ");
            #endif
            LoadGame();
        }

    }
}
