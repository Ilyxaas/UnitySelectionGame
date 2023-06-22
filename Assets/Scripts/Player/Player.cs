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

        public int Money { private set; get; }
        public int RealValue { private set; get; }
        public static BaseLevel InstanceGameLevel { get; set; }

        private Player()   
        {

        }

        public static BaseLevel GetLevel()
        {            
            InstanceGameLevel ??= new Level_0();
            return InstanceGameLevel;
        }

        public static Player GetInstance()
        {
            instance = instance != null ? instance : new();
            return instance;
            
        }

        public static void Print()
        {
            print("123321");
        }

        private void Awake()
        {
            if (instance == null)
                instance = new();

            if (InstanceGameLevel == null)
                InstanceGameLevel = GetLevel();

            ISaveSystem.ConnectionSaveSystem(GetInstance());
            ISaveSystem.ConnectionSaveSystem(InstanceGameLevel);
        }

        string ISaveSystem.GetKey()
        {
            return PlayerKey;
        }

        string ISaveSystem.GetSaveData()
        {
            StringBuilder result = new();
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
