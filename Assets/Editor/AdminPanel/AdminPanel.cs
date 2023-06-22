using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using Assets.Scripts.Save_System;
using Assets.Scripts.Player.Level;

public class AdminPanel : EditorWindow
{
    [MenuItem("Window/Admin Panel")]
    public static void ShowMyEditor()
    {
        // This method is called when the user selects the menu item in the Editor
        EditorWindow wnd = GetWindow<AdminPanel>();
        wnd.titleContent = new GUIContent("Admin Panel");
        
    }

    public void CreateGUI()
    {        
        rootVisualElement.Add(new Label("Welcome to Admin Panel"));        
    }
}
