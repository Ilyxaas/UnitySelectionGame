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
        private OnTouchUISkill UIskillTouch;

        [SerializeField]
        private GameObject BuyUISkillObject;

        private bool UIView = false;
        
        public override Menu GoBack()
        {
            throw new NotImplementedException();
        }

        public override void HitsObjectMenu(RaycastHit[] Hit)
        {
            if (Hit.Count() == 0 && UITouch == false)
            {
                UIView = false;
                
                OnUIOpen.Invoke(UIView);
                return;            
            }

            foreach (var i in Hit)
            {
                if (i.collider.gameObject.TryGetComponent(out SkillView ViewSkill))
                {
                    UIView = true;
                    OnUIOpen.Invoke(UIView);
                }
            }
        }

        

        public override void Load()
        {
            base.Load();
            BuyUISkillObject.SetActive(true);            
        }

        public override void Quit()
        {
            base.Quit();
            BuyUISkillObject.SetActive(false);
        }

        public override void MoveObject(Vector3 DeltaPositon, Vector3 Position)
        {
            
        }

        public override void ScrollMenu(float DeltaPosition)
        {
            
        }
    }
}
