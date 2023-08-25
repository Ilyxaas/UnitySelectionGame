using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Assets.Scripts.Player.Inventory;

[CustomEditor(typeof(WateringCan))]

public class WateringCanEditor : Editor
{
    public override Texture2D RenderStaticPreview(string assetPath, Object[] subAssets, int width, int height)
    {
        var Items = (WateringCan)target;
        if (Items == null || Items.Icon == null)
        {
            Debug.Log("None Texture");
            return null;
        }

        var Texture = new Texture2D(width, height);


        EditorUtility.CopySerialized(Items.Icon.texture, Texture);
        return Texture;
    }    
}
