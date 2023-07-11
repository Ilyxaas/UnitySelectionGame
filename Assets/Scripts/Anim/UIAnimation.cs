using Assets.Scripts.Menu;
using Assets.Scripts.Player.Level;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator UIAnimator;

    private static UIAnimation instance;

    public static UIAnimation GetInstance()
    {
        if (instance == null)
            instance = new();

        return instance;
    }

    private void Awake()
    {
        FindObjectOfType<SkillTreeMenu>().OnUIOpen += delegate(bool value)
        {            
            UIAnimator.SetBool("SkillTreeUI", value);
        };





        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    


}
