using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System;
using UnityEngine.SceneManagement;
using Assets.Scripts.Player.Inventory;
using System.Reflection;

public class InventoryTests 
{

    [UnityTest]
    public IEnumerator InitMenu_1()
    {

        SceneManager.LoadScene(GamePlayLoadTests.MainGameSceneName);
        yield return new WaitForSeconds(1.1f);

        if (Inventory.GetInstance() == null)
            throw new Exception("Inventory Not Found");

        if (InventorySystem.GetInstance() == null)
            throw new Exception("Inventory System Not Found");

        SceneManager.UnloadSceneAsync(GamePlayLoadTests.MainGameSceneName);
        Assert.True(true);
    }

    [UnityTest]
    public IEnumerator InitTitleMenu_2()
    {

        SceneManager.LoadScene(GamePlayLoadTests.MainGameSceneName);

        yield return new WaitForSeconds(1.1f);

        var Object = GameObject.FindObjectsOfType<InventoryBackgroundItemMover>();

        int x = Inventory.GetInstance().MaxElement_X;
        int y = Inventory.GetInstance().MaxElement_Y;

        foreach (var i in Object)
        {
            if (i.X > x || i.X < 0 || i.Y > y || i.Y < 0)
                throw new Exception("Out of Range");
        }

        SceneManager.UnloadSceneAsync(GamePlayLoadTests.MainGameSceneName);
        Assert.True(true);
        
    }

    [UnityTest]
    public IEnumerator DefaultParametrsInit()
    {

        SceneManager.LoadScene(GamePlayLoadTests.MainGameSceneName);

        yield return new WaitForSeconds(1.1f);

        int x = Inventory.GetInstance().CountElement_X;
        int y = Inventory.GetInstance().CountElement_Y;

        int x1 = Inventory.GetInstance().MaxElement_X;
        int y1 = Inventory.GetInstance().MaxElement_Y;

        if (x > x1 || y > y1)
            throw new Exception("Out of Range");

        SceneManager.UnloadSceneAsync(GamePlayLoadTests.MainGameSceneName);
        Assert.True(true);
    }

    [UnityTest]
    public IEnumerator ItemMoverTestInit()
    {

        SceneManager.LoadScene(GamePlayLoadTests.MainGameSceneName);

        yield return new WaitForSeconds(1.1f);

        var Object = GameObject.FindObjectsOfType<InventoryItemMover>();
        
        foreach (InventoryItemMover i in Object)
        {
            Type MoverType = typeof(InventoryItemMover);

            PropertyInfo Rect =
                MoverType.GetProperty("Rect");

            if (Rect.GetValue(i) == null)
                throw new Exception("Null Exception");
        }

        SceneManager.UnloadSceneAsync(GamePlayLoadTests.MainGameSceneName);
        Assert.True(true);
    }

    [UnityTest]
    public IEnumerator AddItemInventory_1()
    {

        SceneManager.LoadScene(GamePlayLoadTests.MainGameSceneName);

        yield return new WaitForSeconds(1.1f);

        Shovel shovel = new Shovel();

        Inventory.GetInstance().Add(shovel);

        if (Inventory.GetInstance().GetItem(0,0).Empty() == true)
            throw new Exception("Item not add");

        SceneManager.UnloadSceneAsync(GamePlayLoadTests.MainGameSceneName);
        Assert.True(true);
    }

    [UnityTest]
    public IEnumerator AddItemInventory_2()
    {

        SceneManager.LoadScene(GamePlayLoadTests.MainGameSceneName);

        yield return new WaitForSeconds(1.1f);

        for (int i = 0; i < Inventory.GetInstance().CountElement_X; i++)
            for (int j = 0; j < Inventory.GetInstance().CountElement_Y; j++)
            {
                Shovel shovel = new Shovel();
                Inventory.GetInstance().Add(shovel);
            }        

        if (Inventory.GetInstance().IsFull() == false)
            throw new Exception("Inventory No FUll");

        SceneManager.UnloadSceneAsync(GamePlayLoadTests.MainGameSceneName);

        Assert.True(true);
    }

    [UnityTest]
    public IEnumerator AddItemInventory_3()
    {

        SceneManager.LoadScene(GamePlayLoadTests.MainGameSceneName);

        yield return new WaitForSeconds(1.1f);

        for (int i = 0; i < Inventory.GetInstance().CountElement_X; i++)
            for (int j = 0; j < Inventory.GetInstance().CountElement_Y; j++)
            {
                Shovel shovel = new Shovel();
                Inventory.GetInstance().Add(shovel);
            }

        Inventory.GetInstance().IsFull(out (int?, int?) res);
        if (res.Item1 != null && res.Item2 != null)
            throw new Exception("Full Index out Of Range");

        SceneManager.UnloadSceneAsync(GamePlayLoadTests.MainGameSceneName);

        Assert.True(true);
    }


    [UnityTest]
    public IEnumerator SwapInventory_1()
    {

        SceneManager.LoadScene(GamePlayLoadTests.MainGameSceneName);

        yield return new WaitForSeconds(1.1f);

        Inventory.GetInstance().Add(ScriptableObject.CreateInstance<Shovel>());

        Inventory.GetInstance().Swap(0, 0, 3, 3);

        if (Inventory.GetInstance().GetItem(0,0).Empty() == false || Inventory.GetInstance().GetItem(3, 3).Empty() == true)
            throw new Exception("Swap Inventory Crash");

        SceneManager.UnloadSceneAsync(GamePlayLoadTests.MainGameSceneName);

        Assert.True(true);
    }

    [UnityTest]
    public IEnumerator SwapInventory_2()
    {

        int count = 10;

        SceneManager.LoadScene(GamePlayLoadTests.MainGameSceneName);

        yield return new WaitForSeconds(1.1f);

        Inventory.GetInstance().Add(ScriptableObject.CreateInstance<Shovel>());


        for (int i = 0; i < count; i++)
        {
            Inventory.GetInstance().Swap(0, 0, 3, 3);
            
            if (Inventory.GetInstance().GetItem(0, 0).Empty() == false || Inventory.GetInstance().GetItem(3, 3).Empty() == true)
            {
                Inventory.GetInstance().Print();
                throw new Exception($"Swap Inventory Crash 1  i = {i}");
            }

            yield return new WaitForSeconds(0.1f);
            Inventory.GetInstance().Swap(0, 0, 3, 3);
            if (Inventory.GetInstance().GetItem(3, 3).Empty() == false || Inventory.GetInstance().GetItem(0, 0).Empty() == true)
            {
                Inventory.GetInstance().Print();
                throw new Exception( $"Swap Inventory Crash 2 i = {i}");
            }

            yield return new WaitForSeconds(0.1f);
        }

        SceneManager.UnloadSceneAsync(GamePlayLoadTests.MainGameSceneName);

        Assert.True(true);
    }  


    [UnityTest]
    public IEnumerator ParentUI_1()
    {

        SceneManager.LoadScene(GamePlayLoadTests.MainGameSceneName);

        yield return new WaitForSeconds(1.1f);

        if (Inventory.GetInstance().GetParent(0, 0) == null)
            throw new Exception("Parent Not Found");
            

        SceneManager.UnloadSceneAsync(GamePlayLoadTests.MainGameSceneName);

        Assert.True(true);
    }


    
}
