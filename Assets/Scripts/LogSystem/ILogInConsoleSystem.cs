using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.Scripts.Admin;


public interface ILogInConsoleSystem 
{
    public static void ConsoleMessage(string Message)
    {
    #if UNITY_EDITOR   
        if (AdminPanelData.DebugInConsole)
        {
            DateTime time = DateTime.Now;
            Debug.Log($"Debug {time.Date} : {Message}");
        }
    #endif
    }

}
