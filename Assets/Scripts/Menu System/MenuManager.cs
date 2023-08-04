using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Menu
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField]
        private Camera CurentCamera;
        static MenuManager instance;
        [SerializeField]
        private Menu curentMenu;

        public Menu CurentMenu { get => curentMenu; private set => curentMenu = value; }

        public void Awake()
        {
            if (instance == null)
                instance = this;

            else if (instance != null)
            {                
                Destroy(this);
            }

            foreach (var i in FindObjectsOfType<Menu>())            
                i.Quit();
            
        }

        public void Start()
        {
            CurentMenu.Load();
        }

        public static Borders GetBordersCurentMenu()
        {
            return instance.curentMenu.GetBordersMenu();
        }

        public static MenuManager GetInstanse()
        { 
            if (instance == null)
                instance = new MenuManager();
            return instance; 

        }

        public void SetUITouch(bool value) => curentMenu.SetUITouch(value);
    }
}
