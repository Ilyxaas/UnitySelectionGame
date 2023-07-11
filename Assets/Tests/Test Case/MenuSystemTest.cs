using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System;
using System.Diagnostics;
using Assets.Scripts.Menu;
using System.Runtime.InteropServices;

public class MenuSystemTest
{
    [UnityTest]
    public IEnumerator BorderInitial()
    {
        Borders border = new
            (new Vector3(1, 1, 0),
             new Vector3(0, 1, 0),
             new Vector3(0, 0, 0),
             new Vector3(1, 0, 0)
            );

        yield return new WaitForSeconds(0f);
        Assert.True(
            border.LeftLower == new Vector3(0, 0, 0) && border.RightLower == new Vector3(1, 0, 0) &&
            border.RightTop == new Vector3(1, 1, 0) && border.LeftTop == new Vector3(0, 1, 0)
            );
    }

    [UnityTest]
    public IEnumerator BorderMoreBorder_1()
    {
        Borders border = new
            (new Vector3(1, 1, 0),
             new Vector3(0, 1, 0),
             new Vector3(0, 0, 0),
             new Vector3(1, 0, 0)
            );

        Borders border3 = new
            (new Vector3(2, 2, 0),
             new Vector3(-1, 2, 0),
             new Vector3(-1, -1, 0),
             new Vector3(2, -1, 0)
            );

        yield return new WaitForSeconds(0f);
        Assert.True( border < border3);
    }

    [UnityTest]
    public IEnumerator BorderMoreBorder_2()
    {
        Borders border = new
            (new Vector3(1, 1, 0),
             new Vector3(0, 1, 0),
             new Vector3(0, 0, 0),
             new Vector3(1, 0, 0)
            );

        Borders border2 = new
            (new Vector3(2, 2, 0),
             new Vector3(0, 2, 0),
             new Vector3(0, 0, 0),
             new Vector3(2, 0, 0)
            );
        yield return new WaitForSeconds(0f);
        Assert.True(border < border2);
    }

    [UnityTest]
    public IEnumerator BorderMoreBorder_3()
    {
        Borders border = new
            (new Vector3( 1,  1, 0),
             new Vector3(-1,  1, 0),
             new Vector3(-1, -1, 0),
             new Vector3( 1, -1, 0)
            );

        Borders border2 = new
            (new Vector3(2, 2, 0),
             new Vector3(0, 2, 0),
             new Vector3(0, 0, 0),
             new Vector3(2, 0, 0)
            );
        yield return new WaitForSeconds(0f);
        Assert.True(border2 < border);
    }

    [UnityTest]
    public IEnumerator BorderMoreBorder_4()
    {
        Borders border = new
            (new Vector3(1, 1, 0),
             new Vector3(0, 1, 0),
             new Vector3(0, 0, 0),
             new Vector3(1, 0, 0)
            );

        Borders border3 = new
            (new Vector3(2, 2, 0),
             new Vector3(-1, 2, 0),
             new Vector3(-1, -1, 0),
             new Vector3(2, -1, 0)
            );

        yield return new WaitForSeconds(0f);
        Assert.True(border3 > border);
    }

    [UnityTest]
    public IEnumerator BorderEqual_1()
    {
        Borders border = new
            (new Vector3(1, 1, 0),
             new Vector3(0, 1, 0),
             new Vector3(0, 0, 0),
             new Vector3(1, 0, 0)
            );

        Borders border3 = new
            (new Vector3(1, 1, 0),
             new Vector3(0, 1, 0),
             new Vector3(0, 0, 0),
             new Vector3(1, 0, 0)
            );

        yield return new WaitForSeconds(0f);
        Assert.True(border3 == border);
    }

    [UnityTest]
    public IEnumerator BorderEqual_2()
    {
        Borders border = new
            (new Vector3(1, 1, 0),
             new Vector3(0, 1, 0),
             new Vector3(0, 0, 0),
             new Vector3(1, 0, 0)
            );

        Borders border3 = new
            (new Vector3(1, 1, 0),
             new Vector3(-1, 1, 0),
             new Vector3(-1, -1, 0),
             new Vector3(1, -1, 0)
            );

        yield return new WaitForSeconds(0f);
        Assert.True(border3 != border);
    }

    [UnityTest]
    public IEnumerator BorderSum_1()
    {
        Borders border = new
            (new Vector3(1, 1, 0),
             new Vector3(0, 1, 0),
             new Vector3(0, 0, 0),
             new Vector3(1, 0, 0)
            );

        Borders BorderResult = new
            (new Vector3(2, 2, 0),
             new Vector3(1, 2, 0),
             new Vector3(1, 1, 0),
             new Vector3(2, 1, 0)
            );

        Vector3 value = new(1, 1, 0);        

        var result = border + value;
        UnityEngine.Debug.Log(result);
        UnityEngine.Debug.Log(BorderResult);
        yield return new WaitForSeconds(0f);
        Assert.True(BorderResult.Equals(result));
    }

    [UnityTest]
    public IEnumerator BorderSum_2()
    {
        Borders border = new
            (new Vector3(1, 1, 0),
             new Vector3(0, 1, 0),
             new Vector3(0, 0, 0),
             new Vector3(1, 0, 0)
            );

        Borders BorderResult = new
            (new Vector3(2, 0, 0),
             new Vector3(1, 0, 0),
             new Vector3(1, -1, 0),
             new Vector3(2, -1, 0)
            );

        Vector3 value = new(1, -1, 0);

        var result = border + value;        
        yield return new WaitForSeconds(0f);
        Assert.True(BorderResult.Equals(result));
    }

    [UnityTest]
    public IEnumerator BorderSenter_1()
    {
        Borders border = new
            (new Vector3(1, 1, 0),
             new Vector3(0, 1, 0),
             new Vector3(0, 0, 0),
             new Vector3(1, 0, 0)
            );        
        
        yield return new WaitForSeconds(0f);
        Assert.True(border.CenterPosition().Equals(new Vector2(0.5f, 0.5f)));
    }

    [UnityTest]
    public IEnumerator BorderSenter_2()
    {
        Borders border = new
            (new Vector3(2, 2, 0),
             new Vector3(-2, 2, 0),
             new Vector3(-2, -2, 0),
             new Vector3(2, -2, 0)
            );

        yield return new WaitForSeconds(0f);
        Assert.True(border.CenterPosition().Equals(new Vector2(0, 0)));
    }

    [UnityTest]
    public IEnumerator BorderMultyply_1()
    {
        Borders border = new
            (new Vector3(1, 1, 0),
             new Vector3(0, 1, 0),
             new Vector3(0, 0, 0),
             new Vector3(1, 0, 0)
            );

        Borders BorderResult = new
            (new Vector3(6, 6, 0),
             new Vector3(-5, 6, 0),
             new Vector3(-5, -5, 0),
             new Vector3(6, -5, 0)
            );

        float value = 5;

        var result = border * value;        
        yield return new WaitForSeconds(0f);
        Assert.True(BorderResult.Equals(result));
    }

    [UnityTest]
    public IEnumerator Border_IsReal_1()
    {
        Borders border = new
            (new Vector3(1, 1, 0),
             new Vector3(0, 1, 0),
             new Vector3(0, 0, 0),
             new Vector3(1, 0, 0)
            );

        Borders BorderResult = new
            (new Vector3(6, 6, 0),
             new Vector3(-5, 6, 0),
             new Vector3(-5, -5, 0),
             new Vector3(6, -5, 0)
            );
        
        yield return new WaitForSeconds(0f);
        Assert.True(true);
    }

    


}
