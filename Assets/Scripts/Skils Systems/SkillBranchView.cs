using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player.Skill
{

    public class SkillBranchView : MonoBehaviour
    {
        [Header("Фон закрытого навыка")]
        [SerializeField]
        private Sprite BranchLock;

        [Header("Фон открытого к покупке навыка")]
        [SerializeField]
        private Sprite BranchNotBuy;

        [Header("Фон открытого и купленного навыка")]
        [SerializeField]
        private Sprite BranchOpenAndBuy;

        [Header("Следующий навык")]
        [SerializeField]
        SkillView Next;

        [Header("Предыдущий навык")]
        [SerializeField]
        SkillView Prev;
    }
}
