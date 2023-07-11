using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using Assets.Scripts.Save_System;
using Assets.Scripts.Player;
using Assets.Scripts.Player.Level;
using System;
using System.Diagnostics;


public class SaveSystemTest
{
    [UnityTest]
    public IEnumerator SavePlayer_1()
    {

        var obj1 = UnityEngine.Object.Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube));

        obj1.AddComponent< Player>();

        obj1.GetComponent<Player>().BaseLoadData();
                
        yield return new WaitForSeconds(1.1f);

        Assert.True(obj1.GetComponent<Player>().Money == 0);
    }

    [UnityTest]
    public IEnumerator ConnectionSaveSystem()
    {

        var obj1 = UnityEngine.Object.Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube));

        var obj2 = UnityEngine.Object.Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube));


        obj1.AddComponent<Player>();
        obj2.AddComponent<SaveSystem>();
        
        yield return new WaitForSeconds(1.1f);

        UnityEngine.Debug.Log(SaveSystem.CountConnection());
        UnityEngine.Debug.Log(SaveSystem.GetInstance());

        Assert.True(SaveSystem.CountConnection() == 2);
    }


    [UnityTest]
    public IEnumerator SingleSaveSistem()
    {
        var obj1 = UnityEngine.Object.Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube));

        var obj2 = UnityEngine.Object.Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube));

        var obj3 = UnityEngine.Object.Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube));

        obj1.AddComponent<SaveSystem>();

        obj2.AddComponent<SaveSystem>();

        obj3.AddComponent<SaveSystem>();

        yield return new WaitForSeconds(1.5f);

        UnityEngine.Debug.Log(obj2);

        Assert.True(obj2.TryGetComponent(out SaveSystem _) == false
            && obj3.TryGetComponent(out SaveSystem _) == false);         
    }

    [UnityTest]
    public IEnumerator ZeroObjectConnectionInInstanseSaveSystem()
    {
        var obj1 = UnityEngine.Object.Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube));        

        obj1.AddComponent<SaveSystem>();

        yield return new WaitForSeconds(1.5f);

        UnityEngine.Debug.Log(obj1);

        Assert.True(SaveSystem.CountConnection() == 0);
    }

}
