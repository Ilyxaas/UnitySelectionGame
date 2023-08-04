using Assets.Scripts.Menu;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Menu
{
    public class RayCastSystem : MonoBehaviour
    {
        //private MenuManager menuManager => MenuManager.GetInstanse();

        static RayCastSystem instance;

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

        public static RayCastSystem GetInstanse()
        {
            return instance;
        }

        public RaycastHit[] GetRayCastHitObject(Vector2 ScreenPos)
        {
            Ray Ray = Camera.main.ScreenPointToRay(ScreenPos);
            var Hits = Physics.RaycastAll(Ray);
            //print(Hits.Count());
            return Hits;
        }
    }
}
