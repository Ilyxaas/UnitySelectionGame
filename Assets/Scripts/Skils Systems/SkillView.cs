using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player.Skill
{
    public class SkillView : MonoBehaviour
    {
        [Header("��� ��������� ������")]
        [SerializeField]
        private Sprite BackGroundLock;

        [Header("��� ��������� � ������� ������")]
        [SerializeField]
        private Sprite BackGroundOpenNotBuy;

        [Header("��� ��������� � ���������� ������")]
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
