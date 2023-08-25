using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class EditorPlayerPrefs : EditorWindow
{
    [MenuItem("Game/ClearAll")]
    public static void ClearAllPlayerPreft()
    {
        PlayerPrefs.DeleteAll();
    }
}
