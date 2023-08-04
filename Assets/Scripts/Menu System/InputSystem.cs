using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Menu
{

    public class InputSystem : MonoBehaviour
    {
        static InputSystem instance;        

        [SerializeField]
        private float SensivityMove;

        [SerializeField]
        private float SensivityScale;

        [SerializeField]
        private float DownDistanse;

        
        private Vector2 StartPos1, StartPos2;
        private float Distanse;
        private float StartDistanse;

        public void Awake()
        {
            if (instance == null)
                instance = this;

            else if (instance != null)
            {
                print("Destroy");
                Destroy(this);
            }
        }

        public void Update()
        {            
            if (Input.touchCount == 1)
            {
               Touch touch = Input.GetTouch(0);  
               switch (touch.phase)
               {
                    case TouchPhase.Began:
                    {
                           MenuManager.GetInstanse().CurentMenu.HitsObjectMenu(
                               RayCastSystem.GetInstanse().GetRayCastHitObject(touch.position)
                               );
                        break;
                    }
                    case TouchPhase.Moved:
                    {
                        CameraManager.GetInstance().MoveCamera(-1 * SensivityMove * touch.deltaPosition);
                        MenuManager.GetInstanse().CurentMenu.MoveObject(touch.deltaPosition, touch.position);
                        break;
                    }                        
               }
            }

            if (Input.touchCount == 2)
            {
                Touch touch1 = Input.GetTouch(0);
                Touch touch2 = Input.GetTouch(1);

                if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
                {
                    StartPos1 = touch1.position;
                    StartPos2 = touch1.position;
                    var CurentDistanse = Vector2.Distance(StartPos1, StartPos2);
                    StartDistanse = CurentDistanse;
                    print("Start Distanse = " + StartDistanse);
                }


                if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
                {
                    var CurentDistanse = Vector2.Distance(touch1.position, touch2.position);
                    float Scale = Distanse / CurentDistanse;
                    Distanse = CurentDistanse;
                    CameraManager.GetInstance().ScaleCamera((Scale - 1) * SensivityScale);                  
                    
                }

                MenuManager.GetInstanse().CurentMenu.ScrollMenu(touch1.deltaPosition.y + touch2.deltaPosition.y);


            }
                

        }
    }
}
