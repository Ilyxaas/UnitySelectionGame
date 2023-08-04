using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AlphaButton : MonoBehaviour   
{
    private Image Image => GetComponent<Image>();

    [Range(0, 1)]
    [SerializeField]
    private float Alpha;


}
