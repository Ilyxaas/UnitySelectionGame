using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Player.Skill;

public sealed class SkillSystem : MonoBehaviour
{
    public static SkillSystem instance;
    [SerializeField]
    private Skill baseSkill;
    public Skill BaseSkill { get => baseSkill; private set => baseSkill = value; }
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
        
    }

    public static List<Skill> GetPurchasedSkill()
    {
        List<Skill> result = new List<Skill>();

        foreach (Skill i in instance.baseSkill.NextSkill)
            CheckSkill(i);

        void CheckSkill(Skill curent)
        {
            if (curent.IsLock == false)
            {
                result.Add(curent);
                foreach (Skill j in curent.NextSkill)
                    CheckSkill(j);
            } 
        }
        return result;
    }

    






}
