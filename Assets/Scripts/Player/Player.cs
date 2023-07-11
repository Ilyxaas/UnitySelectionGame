using Assets.Scripts.Player.Skill;
using Assets.Scripts.Save_System;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

namespace Assets.Scripts.Player.Level
{
    [Serializable]
    public sealed class Player : MonoBehaviour, ISaveSystem
    {        
        private const string PlayerKey = "PlayerSave";
        
        private static Player instance = null;

        [SerializeField]
        private int money = 0;
        [SerializeField]
        private int realMoney = 0;
        
        public int Money { get => money; private set => money = value; }
        public int RealMoney { get => realMoney; private set => realMoney = value; }
        
        public static BaseLevel InstanceGameLevel { get; set; }

        private Player()
        {
            Money = 0;
            RealMoney = 0;
        }

        public static BaseLevel GetLevel()
        {
            InstanceGameLevel ??= new Level_0();
            return InstanceGameLevel;
        }

        public static Player GetInstance()
        {
            if (instance == null)
                instance = new();

            return instance;
        }

        public static int Print(int i)
        {
            print("123321");
            return i;
        }

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(this);

            if (InstanceGameLevel == null)
                InstanceGameLevel = GetLevel();
        }

        private void Start()
        {
            ISaveSystem.ConnectionSaveSystem(GetInstance());
            ISaveSystem.ConnectionSaveSystem(InstanceGameLevel);            
        }

        public string GetKey()
        {
            return PlayerKey;
        }

        string ISaveSystem.GetSaveData()
        {
            StringBuilder result = new();
            result.Append(Money);
            result.Append(" ");
            result.Append(RealMoney);
            return result.ToString();
        }

        void ISaveSystem.LoadData(string val)
        {
            string[] data = val.Split(' ');
            Money = int.Parse(data[0]);
            RealMoney = int.Parse(data[1]);
        }

        public void BaseLoadData()
        {
            Money = 0;
            RealMoney = 0;
        }
    }
}
