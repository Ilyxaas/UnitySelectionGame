using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using Assets.Scripts.Struct;
using System;
using System.Reflection;

public class StructTests : MonoBehaviour
{
    [UnityTest]
    public IEnumerator InitLinkedList_1()
    {
        LinkedList<int> list = new LinkedList<int>();

        yield return new WaitForSeconds(0.1f);
        Assert.True(true);
    }

    [UnityTest]
    public IEnumerator InitLinkedList_AddObject_1()
    {
        LinkedList<int> list = new LinkedList<int>();
        list.Add(5);        
        yield return new WaitForSeconds(0.1f);
        if (list.Lenght() == 1)
            Assert.True(true);
        else
            Assert.True(false);

    }

    [UnityTest]
    public IEnumerator InitLinkedList_AddObject_2()
    {
        LinkedList<int> list = new LinkedList<int>();
        list.Add(5);
        list.Add(23);        
        yield return new WaitForSeconds(0.1f);
        if (list.Lenght() == 2)
            Assert.True(true);
        else
            Assert.True(false);

    }

    [UnityTest]
    public IEnumerator InitLinkedList_AddObject_3()
    {
        LinkedList<int> list = new LinkedList<int>();
        list.Add(5);
        list.Add(23);
        list.Add(23);
        yield return new WaitForSeconds(0.1f);
        if (list.Lenght() == 3)
            Assert.True(true);
        else
            Assert.True(false);

    }

    [UnityTest]
    public IEnumerator InitLinkedList_GetValue_1()
    {
        LinkedList<int> list = new LinkedList<int>();
        list.Add(5);
        list.Add(23);
        list.Add(25);
        yield return new WaitForSeconds(0.1f);
        if (list[0].value == 5 && list[1].value == 23 && list[2].value == 25)
            Assert.True(true);
        else
            Assert.True(false);
    }

    [UnityTest]
    public IEnumerator InitLinkedList_GetValue_2()
    {
        LinkedList<int> list = new LinkedList<int>();
        list.Add(5);
        list.Add(23);
        list.Add(25);
        yield return new WaitForSeconds(0.1f);
        if (list[0].next.next.next.value == 5)
            Assert.True(true);
        else
            Assert.True(false);
    }

    [UnityTest]
    public IEnumerator InitLinkedList_Move_Left()
    {
        LinkedList<int> list = new LinkedList<int>();
        list.Add(5);
        list.Add(23);
        list.Add(25);
        Debug.Log($"{list[0].value} {list[1].value} {list[2].value}");
        list.MoveLeft();
        Debug.Log($"{list[0].value} {list[1].value} {list[2].value}");
        yield return new WaitForSeconds(0.1f);
        if (list[0].value ==23 && list[1].value == 25 && list[2].value == 5)
            Assert.True(true);
        else
            Assert.True(false);
    }

    [UnityTest]
    public IEnumerator InitLinkedList_Move_Right()
    {
        LinkedList<int> list = new LinkedList<int>();
        list.Add(5);
        list.Add(23);
        list.Add(25);
        Debug.Log($"{list[0].value} {list[1].value} {list[2].value}");
        list.MoveRight();
        Debug.Log($"{list[0].value} {list[1].value} {list[2].value}");
        yield return new WaitForSeconds(0.1f);
        if (list[0].value == 25 && list[1].value == 5 && list[2].value == 23)
            Assert.True(true);
        else
            Assert.True(false);
    }


}
