using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using System.Runtime.InteropServices;

namespace Assets.Scripts.Menu
{

    public class CameraManager : MonoBehaviour
    {
        static CameraManager instance;
        private Camera CurrentCamera => GetComponent<Camera>();

        public void Awake()
        {             
            if (instance == null)
                instance = this;

            else if (instance != null)
            {                
                Destroy(this);
            }
        }

        public static CameraManager GetInstance()
        {
            if (instance == null)
                instance = new();
            return instance;
        }

        public Borders GetMainCameraBorders()
        {
            return new Borders(
                Camera.main.ViewportToWorldPoint(new Vector2(CurrentCamera.rect.xMax, CurrentCamera.rect.yMax)),
                Camera.main.ViewportToWorldPoint(new Vector2(CurrentCamera.rect.xMin, CurrentCamera.rect.yMax)),
                Camera.main.ViewportToWorldPoint(new Vector2(CurrentCamera.rect.xMin, CurrentCamera.rect.yMin)),
                Camera.main.ViewportToWorldPoint(new Vector2(CurrentCamera.rect.xMax, CurrentCamera.rect.yMin))
                );
        }

        private void Start()
        {
            //print(GetMainCameraBorders());
            CurrentCamera.orthographicSize += 1;
            //print(GetMainCameraBorders());
        }

        public bool MoveCamera(Vector2 value)
        {
            if (MenuManager.GetInstanse().CurentMenu.IsMove == false)
                return false;

            if (MenuManager.GetBordersCurentMenu() > (GetMainCameraBorders() + value))
            {
                print(2);
                CurrentCamera.gameObject.transform.Translate(value);
                return true;
            }
            return false;
        }

        public bool ScaleCamera(float value) 
        {
            if (MenuManager.GetInstanse().CurentMenu.IsScale == false)
                return false;

            if (MenuManager.GetBordersCurentMenu() > (GetMainCameraBorders() * value))
            {                
                CurrentCamera.orthographicSize += value;
                return true;
            }
            else
                print("Вышли за рамки");
            return false;
        }
    }



    [Serializable]
    public sealed class Borders
    {
        [SerializeField]
        public Vector3 LeftTop { get; private set; }
        [SerializeField]
        public Vector3 RightTop { get; private set; }
        [SerializeField]
        public Vector3 LeftLower { get; private set; }
        [SerializeField]
        public Vector3 RightLower { get; private set; }

        private float SizeX;

        private float SizeY;

        public Borders(Vector3 rightTop, Vector3 leftTop, Vector3 leftLower, Vector3 rightLower)
        {
            LeftTop = leftTop;
            RightTop = rightTop;
            LeftLower = leftLower;
            RightLower = rightLower;

            if (IsRealObject() == false)
            {
                Debug.Log(this);
                throw new Exception("Bordes is not Real");
            }
            SizeX = rightTop.x - leftLower.x;
            SizeY = RightTop.x - RightLower.y;
        }

        public override string ToString()
        {
            StringBuilder result = new();
            result.Append("Left Top = " + LeftTop.ToString() + Environment.NewLine);
            result.Append("Left Lower = " + LeftLower.ToString() + Environment.NewLine);
            result.Append("Right Top = " + RightTop.ToString() + Environment.NewLine);
            result.Append("Right Lower = " + RightLower.ToString() + Environment.NewLine);
            return result.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is Borders borders &&
                   LeftTop.Equals(borders.LeftTop) &&
                   RightTop.Equals(borders.RightTop) &&
                   LeftLower.Equals(borders.LeftLower) &&
                   RightLower.Equals(borders.RightLower);
        }

        private bool IsRealObject()
        {
            if (
                (LeftTop.x - LeftLower.x) < Mathf.Epsilon && (RightTop.x - RightLower.x) < Mathf.Epsilon &&
                (LeftTop.y - RightTop.y) < Mathf.Epsilon && (LeftLower.y - RightLower.y) < Mathf.Epsilon &&
                LeftTop.y > LeftLower.y && RightTop.y > RightLower.y &&
                LeftTop.x < RightTop.x && LeftLower.x < RightLower.x
                )
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(LeftTop, RightTop, LeftLower, RightLower);
        }

        public static bool operator > (Borders left, Borders right)
        {
            if (left.LeftTop.x < right.LeftTop.x && left.LeftTop.y > right.LeftTop.y &&
                left.RightTop.x > right.RightTop.x && left.RightLower.y < right.RightLower.y)                            
                return true;
            return false;
        }

        public static bool operator < (Borders left, Borders right)
        {
            if (left > right)
                return false;            
            return true;            
        }

        public static bool operator == (Borders left, Borders right)
        {
            bool Eq = left.Equals(right);
            if (Eq) 
                return true;            
            return false;            
        }

        public static bool operator != (Borders left, Borders right)
        {
            bool Eq = left.Equals(right);
            if (Eq) 
                return false;            
            return true;
        }

        public static Borders operator + (Borders borders, Vector3 value)
        {
            Borders NewBorders = new
                (
                    borders.RightTop + value,
                    borders.LeftTop + value,
                    borders.LeftLower + value,
                    borders.RightLower + value  
                );           
            return NewBorders;
        }
        public static Borders operator - (Borders borders, Vector3 value)
        {
            Borders NewBorders = new
                (
                    borders.RightTop - value,
                    borders.LeftTop - value,
                    borders.LeftLower - value,
                    borders.RightLower - value
                );
            return NewBorders;
        }

        public static Borders operator * (Borders borders, float value)
        {
            float AbsValue = Mathf.Abs(value);
            Borders NewBorders = new
                (
                    borders.RightTop + new Vector3 (AbsValue, AbsValue, 0),
                    borders.LeftTop + new Vector3(-AbsValue, AbsValue, 0),
                    borders.LeftLower + new Vector3(-AbsValue, -AbsValue, 0),
                    borders.RightLower + new Vector3(AbsValue, -AbsValue, 0)
                );;
            return NewBorders;
        }

        public Vector2 CenterPosition()
        {
            return new Vector2(RightTop.x - (SizeX / 2), RightTop.y - (SizeY / 2));
        }
    }
}
