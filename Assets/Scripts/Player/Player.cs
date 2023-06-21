using Assets.Scripts.Save_System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

namespace Assets.Scripts.Player.Level
{
    public class Player : MonoBehaviour, ISaveSystem
    {
        private const string PlayerKey = "PlayerSave";
        private static Player instance;
        private static object syncRoot = new Object();

        public int Money { private set; get; }
        public int RealValue { private set; get; }

        public static BaseLevel CurentGameLevel 
        {
            get 
            {
                if (CurentGameLevel == null)
                    throw new System.Exception("Level is not instanse");              
                return CurentGameLevel;
            }
            set { CurentGameLevel = value; }
            
        }

        private Player()
        {

        }

        public static Player getInstance()
        {
            print(instance);
            if (instance == null)
            {
                instance = new();
                    
            }
            return instance;
            
        }        

        private void Start()
        {
            print(2);
            if (instance == null)
                instance = new();
            ISaveSystem.ConnectionSaveSystem(getInstance());
            ISaveSystem.ConnectionSaveSystem(CurentGameLevel);
           // DontDestroyOnLoad(gameObject);
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

        public void BaseLoadData()
        {
            Money = 0;
            RealValue = 0;
        }
    }
}
