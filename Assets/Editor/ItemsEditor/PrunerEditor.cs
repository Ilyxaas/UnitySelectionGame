using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Assets.Scripts.Player.Inventory;

[CustomEditor(typeof(Pruner))]
public class PrunerEditor : Editor
{
    public override Texture2D RenderStaticPreview(string assetPath, Object[] subAssets, int width, int height)
    {
        var Items = (Pruner)target;
        if (Items == null || Items.Icon == null)
            return null;

        var Texture = new Texture2D(width, height);
        EditorUtility.CopySerialized(Items.Icon.texture, Texture);

        return Texture;
    }
}

