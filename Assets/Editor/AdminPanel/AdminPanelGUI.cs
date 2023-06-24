using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using Assets.Scripts.Save_System;
using Assets.Scripts.Player.Level;
using Assets.Scripts.Admin;

public class AdminPanelGUI : EditorWindow
{
    [MenuItem("Window/Admin Panel")]
    public static void ShowMyEditor()
    {
        // This method is called when the user selects the menu item in the Editor
        EditorWindow wnd = GetWindow<AdminPanelGUI>();
        wnd.titleContent = new GUIContent("Admin Panel");

    }

    public void CreateGUI()
    {
        var DebugMode = new Toggle("Debug log in Console");
        DebugMode.value = AdminPanelData.DebugInConsole;

        DebugMode.RegisterCallback<ClickEvent>(SetDebugInConsole);

        rootVisualElement.Add(new Label("Welcome to Admin Panel"));
        rootVisualElement.Add(DebugMode);
    }

    public static void SetDebugInConsole(ClickEvent e)
    {
        AdminPanelData.DebugInConsole = !AdminPanelData.DebugInConsole;        
    }
}
