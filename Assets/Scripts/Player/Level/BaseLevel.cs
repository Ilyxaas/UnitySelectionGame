using Assets.Scripts.Save_System;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Player.Level
{
    public abstract class BaseLevel : ISaveSystem
    {
        
        protected const string LevelKey = "LevelSave";             
        protected int CurentXpValue { get; set; }
        public abstract void Start();
        public abstract BaseLevel AddXp(int value);
        public abstract int GetLevel();

        protected bool BaseAddXp(int value, int NecessaryXPValue, out int superfluous)
        {
            if (CurentXpValue + value >= NecessaryXPValue)
            {                
                superfluous = (CurentXpValue + value) % NecessaryXPValue;
                return true;
            }
            else
            {
                CurentXpValue += value;
                superfluous = 0;
                return false;
            }
        }

        public string GetSaveData()
        {
            StringBuilder sb = new();
            sb.Append(GetLevel() + " " + CurentXpValue);
            return sb.ToString();
        }

        public void LoadData(string val)
        {
            var split = val.Split();
            int level = int.Parse(split[0]);
            int CurentXp = int.Parse(split[1]);
            switch (level)
            {
                case 0: { Player.InstanceGameLevel = new Level_0(CurentXp); break; }
                case 1: { Player.InstanceGameLevel = new Level_1(CurentXp); break; }
                default: { throw new Exception("Уровень не определен"); }
            }
        }

        public string GetKey()
        {
            return LevelKey;
        }

        public void BaseLoadData()
        {
            Player.InstanceGameLevel = new Level_0(0);
        }        
    }
}
