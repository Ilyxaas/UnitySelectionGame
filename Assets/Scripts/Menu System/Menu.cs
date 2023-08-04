using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Menu
{
    public delegate void UIEvent(bool value);

    public abstract class Menu : MonoBehaviour
    {
        protected Camera CurrentCamera => Camera.main;

        [SerializeField]
        private GameObject UIParent;

        [SerializeField]
        private GameObject SceneParent;

        [SerializeField]
        public bool UITouch { get; protected set; } = false;

        [SerializeField]
        private bool isMove;

        [SerializeField]
        private bool isScale;

        [Min(0)]
        [SerializeField]
        private float maxValueScale;

        [Min(0)]
        [SerializeField]
        private float minValueScale;

        [Min(0)]
        [SerializeField]
        private float standartValueScale;

        [SerializeField]
        private MenuRect rect;

        [SerializeField]
        private Vector3 standartValueCameraPosition;
        
        public float StandartValueScale { get => standartValueScale; private set => standartValueScale = value; }

        public MenuRect Rect { get => rect; private set => rect = value; }

        public bool IsMove { get => isMove; private set => isMove = value; }

        public bool IsScale { get => isScale; private set => isScale = value; }

        public float MaxValueScale { get => maxValueScale; private set => maxValueScale = value; }

        public float MinValueScale { get => minValueScale; private set => minValueScale = value; }

        public Vector3 StandartValueCameraPosition 
            { get => standartValueCameraPosition; private set => standartValueCameraPosition = value; }

        public abstract Menu GoBack();

        public virtual void Load()
        {
            UIParent.SetActive(true);
        }
        public virtual void Quit()
        {
            UIParent.SetActive(false);
        }

        public abstract void HitsObjectMenu(RaycastHit[] Hit);

        public Borders GetBordersMenu()
        {
            return Rect.PositionToBorders();            
        }

        public void SetUITouch(bool value) => UITouch = value;

        public abstract void MoveObject(Vector3 DeltaPositon, Vector3 Position);

        public abstract void ScrollMenu(float DeltaPosition);

    }
}
