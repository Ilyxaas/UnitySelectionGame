using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

namespace Assets.Scripts.Player.Skill
{
    public class SkillsLocale : MonoBehaviour
    {        
        public LocalizedStringTable SkilsLocaleTable;

        private static SkillsLocale instance;

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(this);
        }

        public static SkillsLocale GetInstanse()
        {
            if (instance == null)
                throw new System.Exception("SkillsLocale is not Found");
            return instance;
        }


    }
}
