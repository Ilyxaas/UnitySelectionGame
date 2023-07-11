using Assets.Scripts.Player.Skill;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Menu
{
    [ExecuteAlways]
    public class SkillTreeMenu : Menu
    {
        public event UIEvent OnUIOpen;

        [SerializeField]
        private GameObject BuyUISkillObject;
        private bool UIView = false;
        public override Menu GoBack()
        {
            throw new NotImplementedException();
        }

        public override void HitsObjectMenu(RaycastHit[] Hit)
        {
            if (Hit.Count() == 0)
            {
                UIView = false;                
                OnUIOpen.Invoke(UIView);
                return;            
            }


            foreach (var i in Hit)
            {
                if (i.collider.gameObject.TryGetComponent<SkillView>(out SkillView ViewSkill))
                {
                    UIView = true;
                    OnUIOpen.Invoke(UIView);
                }
            }
        }

        #if UNITY_EDITOR

        public void Update()
        {            
            CurrentCamera.gameObject.transform.position = StandartValueCameraPosition;
            CurrentCamera.orthographicSize = StandartValueScale;
        }

        #endif

        public override void Load()
        {
            BuyUISkillObject.SetActive(true);            
        }

        public override void Quit()
        {
            BuyUISkillObject.SetActive(false);
        }
    }
}
