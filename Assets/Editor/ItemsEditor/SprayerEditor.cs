using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Assets.Scripts.Player.Inventory;

[CustomEditor(typeof(Sprayer))]
public class SprayerEditor : Editor
{
    public override Texture2D RenderStaticPreview(string assetPath, Object[] subAssets, int width, int height)
    {
        var Items = (Sprayer)target;
        if (Items == null || Items.Icon == null)
        {
            Debug.Log("None Texture");
            //return base.RenderStaticPreview(assetPath, subAssets, width, height);
            return null;
        }

        var Texture = new Texture2D(width, height);


        EditorUtility.CopySerialized(Items.Icon.texture, Texture);



        return Texture;
    }
}