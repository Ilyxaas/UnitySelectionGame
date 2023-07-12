using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Assets.Scripts.Player.Skill
{


    public abstract class Skill : ScriptableObject
    {
        [Header("Cc���� �� Skill View")]
        [SerializeField]
        private SkillView View;

        [Header("����������� ������ ��� �������� �������")]
        public List<Skill> PrevSkill;

        [Header("������ ��� �������� ������� ���������� �������� �������")]
        public List<Skill> NextSkill;

        const string Name = "_name";
        const string Info = "_info";

        public bool IsSecret { get => isSecret; private set => isSecret = value; }
        public bool IsLock { get => isLock; private set => isLock = value; }
        public int Cost { get => cost; private set => cost = value; }
        public int MinimalLevelPlayer
            { get => minimalLevelPlayer; private set => minimalLevelPlayer = value; }
        public string NameSkill { get => nameSkill; private set => nameSkill = value; }

        public UnityEvent EventToUnlock { get => eventToUnlock; private set => eventToUnlock = value; }

        [Space]
        [Header("�������� �� ������� ����� � ������ �� ������ ������")]
        [SerializeField]
        private bool IsWiew = false;

        [Header("�������� �� ���������� ���������")]
        [SerializeField]
        private bool isSecret = false;

        [Header("�������� (ID) ��� ������� ���������")]
        [SerializeField]
        private string nameSkill = "";

        [Header("������� �� ����������")]
        [SerializeField]
        private bool isLock = true;

        [Header("���� � ������� �������")]
        [SerializeField]
        private int cost = 0;

        [Header("����������� ������� ��� ��������")]
        [SerializeField]
        private int minimalLevelPlayer = 1;

        [Space]
        [Header("������� ��� �������� ������")]
        [Space]
        [SerializeField]
        private UnityEvent eventToUnlock;      


        public string GetInfo()
        {
            return SkillsLocale.getInstanse().SkilsLocaleTable.GetTable().GetEntry(NameSkill + Info).Value;
        }

        public string GetName()
        {
            return SkillsLocale.getInstanse().SkilsLocaleTable.GetTable().GetEntry(NameSkill + name).Value; ;
        }
    }

    // ��������� base
    public abstract class ReputationSkill : Skill
    {

    }

    // ��������� Skill
    public abstract class TuyaSkill : Skill
    {

    }

    // ��������� Skill
    public abstract class InventorySkill : Skill
    {

    }

    public abstract class NewShopItemSkill : Skill
    {

    }
    public abstract class PlantSkill : Skill
    {

    }


    [CreateAssetMenu(menuName = "Skill/Base Skill")]
    public class MainSkill : Skill { }


}

