using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using Assets.Scripts.Save_System;
using Assets.Scripts.Player;
using Assets.Scripts.Player.Level;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;

public class PlayerTesting 
{
    [UnityTest]
    public IEnumerator SinglePlayerSistem()
    {
        var obj1 = UnityEngine.Object.Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube));

        var obj2 = UnityEngine.Object.Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube));

        var obj3 = UnityEngine.Object.Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube));

        obj1.AddComponent<Player>();

        obj2.AddComponent<Player>();

        obj3.AddComponent<Player>();

        yield return new WaitForSeconds(1.5f);

        Assert.True(obj2.TryGetComponent(out Player _) == false
            && obj3.TryGetComponent(out Player _) == false);
    }

    [UnityTest]
    public IEnumerator SaveDataPlayer()
    {
        var Player = UnityEngine.Object.Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube));

        var SaveSystem = UnityEngine.Object.Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube));

        Player.AddComponent<Player>();

        SaveSystem.AddComponent<SaveSystem>();

        Type TypePlayer = typeof(Player);

        Type TypeSave = typeof(SaveSystem);

        yield return new WaitForSeconds(1f);

        UnityEngine.Debug.Log(Player.TryGetComponent(out Player obj));

        UnityEngine.Debug.Log(SaveSystem.TryGetComponent(out SaveSystem save));

        PropertyInfo money =
            TypePlayer.GetProperty("Money");

        PropertyInfo realMoney =
            TypePlayer.GetProperty("RealMoney");

        var MetodSave = TypeSave.GetMethod("SaveGame");

        var GetKeyPlayer = TypePlayer.GetMethod("GetKey");

        money.SetValue(obj, 3000);

        realMoney.SetValue(obj, 2000);

        MetodSave.Invoke(save, new object[] { });

        yield return new WaitForSeconds(1.5f);

        string result = PlayerPrefs.GetString((string)GetKeyPlayer.Invoke(obj, new object[] { }));        

        Assert.True(result == "3000 2000");
    }
}
