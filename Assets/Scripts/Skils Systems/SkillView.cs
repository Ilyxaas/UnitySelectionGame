using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player.Skill
{
    public class SkillView : MonoBehaviour
    {
        [Header("Фон закрытого навыка")]
        [SerializeField]
        private Sprite BackGroundLock;

        [Header("Фон открытого к покупке навыка")]
        [SerializeField]
        private Sprite BackGroundOpenNotBuy;

        [Header("Фон открытого и купленного навыка")]
        [SerializeField]
        private Sprite BackGroundOpenAndBuy;

        private Sprite Background => GetComponent<Sprite>();


        [SerializeField]
        private Skill Skill;

        public void UnlockSkill()
        {
        
        }
        
    }
}
