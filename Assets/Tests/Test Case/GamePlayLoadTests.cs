using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System;
using System.Diagnostics;
using Assets.Scripts.Menu;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;
using Assets.Scripts.Player.Level;
using Assets.Scripts.Save_System;
using Assets.Scripts.Player.Skill;

public class GamePlayLoadTests 
{
    public static string MainGameSceneName = "Main";
    public static string LoadGameSceneName = "LoadGame";


    [UnityTest]
    public IEnumerator LoadLevel_1()
    {
        
        SceneManager.LoadScene(MainGameSceneName);

        yield return new WaitForSeconds(1.1f);

        Assert.True(true);
    }

    [UnityTest]
    public IEnumerator LoadSystemObject_1()
    {

        SceneManager.LoadScene(MainGameSceneName);

        yield return new WaitForSeconds(1.1f);

        if (MenuManager.GetInstanse() == null)
            throw new Exception("Menu Manager Not Found");

        if (Player.GetInstance() == null)
            throw new Exception("Player Not Found");

        if (CameraManager.GetInstance() == null) 
            throw new Exception("Camera Manager Not Found");

        if (SaveSystem.GetInstance() == null)
            throw new Exception("SaveSystem not Found");

        if (SkillSystem.GetInstanse() == null)
            throw new Exception("Skill System not Found");        

        Assert.True(true);
    }
}
