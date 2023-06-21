using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

using Assets.Scripts.Save_System;
public class SaveSystemTest
{
    [UnityTest]
    public IEnumerator AsteroidsMoveDown()
    {

        var obj = SaveSystem.getInstance();



        yield return new WaitForSeconds(0.1f);

        Assert.True(true);
    }

}
