using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player.Skill
{

    public class SkillBranchView : MonoBehaviour
    {
        [Header("��� ��������� ������")]
        [SerializeField]
        private Sprite BranchLock;

        [Header("��� ��������� � ������� ������")]
        [SerializeField]
        private Sprite BranchNotBuy;

        [Header("��� ��������� � ���������� ������")]
        [SerializeField]
        private Sprite BranchOpenAndBuy;

        [Header("��������� �����")]
        [SerializeField]
        SkillView Next;

        [Header("���������� �����")]
        [SerializeField]
        SkillView Prev;
    }
}
