using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using Assets.Scripts.Save_System;
using Assets.Scripts.Player;
using Assets.Scripts.Player.Level;
using System;
using System.Diagnostics;

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
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

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
