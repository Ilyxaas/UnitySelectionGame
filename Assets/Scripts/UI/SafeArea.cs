using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
    private void Awake() => SetSafeArea();

    void SetSafeArea() // скрипт который подстраиваем под экраны с челкой
    {
        var S_Area = Screen.safeArea;
        var MyRect = GetComponent<RectTransform>();

        var AnchorMin = S_Area.position;
        var AnchorMax = S_Area.position + S_Area.size;

        AnchorMin.x /= Screen.width;
        AnchorMin.y /= Screen.height;
        AnchorMax.x /= Screen.width;
        AnchorMax.y /= Screen.height;

        MyRect.anchorMax = AnchorMax;
        MyRect.anchorMin = AnchorMin;
    }
}
