using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Assets.Scripts.Player.Skill
{


    public abstract class Skill : ScriptableObject
    {
        [Header("Ccылка на Skill View")]
        [SerializeField]
        private SkillView View;

        [Header("Необходимые навыки для открытия данного")]
        public List<Skill> PrevSkill;

        [Header("Навыки для открытия которых необходимо открытие данного")]
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
        [Header("Возможно ли увидеть навык в дереве на данный момент")]
        [SerializeField]
        private bool IsWiew = false;

        [Header("Является ли достижение секретным")]
        [SerializeField]
        private bool isSecret = false;

        [Header("Название (ID) для таблицы переводов")]
        [SerializeField]
        private string nameSkill = "";

        [Header("Закрыто ли достижение")]
        [SerializeField]
        private bool isLock = true;

        [Header("Цена в игровых монетах")]
        [SerializeField]
        private int cost = 0;

        [Header("Минимальный уровень для открытия")]
        [SerializeField]
        private int minimalLevelPlayer = 1;

        [Space]
        [Header("Событие при открытии навыка")]
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

    // Репутация base
    public abstract class ReputationSkill : Skill
    {

    }

    // Репутация Skill
    public abstract class TuyaSkill : Skill
    {

    }

    // Репутация Skill
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

