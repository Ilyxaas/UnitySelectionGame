using Assets.Scripts.Save_System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Player.Level
{
    public abstract class BaseLevel : ISaveSystem
    {
        
        protected const string LevelKey = "LevelSave";

        private const int StarXpValue = 0;

        protected readonly static int NecessaryXPValue;
        protected int CurentXpValue { get; set; }
        public abstract void Start();
        public abstract BaseLevel GetXp(Player player, int value);
        public abstract int GetLevel();

        public string GetSaveData()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GetLevel() + " " + CurentXpValue);
            return sb.ToString();
        }

        public void LoadData(string val)
        {
            
        }

        public string GetKey()
        {
            return LevelKey;
        }

        public void BaseLoadData()
        {
            
        }        
    }
}
