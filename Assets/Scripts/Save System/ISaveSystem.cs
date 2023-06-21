using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Save_System
{

    public interface ISaveSystem
    {
        public static void ConnectionSaveSystem(ISaveSystem obj) => SaveSystem.AddSaveObject(obj);

        public string GetSaveData();

        public void LoadData(string val);

        public string GetKey();
    }
}
 