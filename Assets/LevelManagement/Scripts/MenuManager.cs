using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{
    public class MenuManager : MonoBehaviour
    {
        public Menu mainMenuPrefab;
        public Menu settingsMenuPrefab;
        public Menu creditsScreenPrefab;

        [SerializeField]
        private Transform _menuParent;

        private void Awake()
        {
            InitializeMenus();
        }

        private void InitializeMenus()
        {
            if (_menuParent == null)
            {
                GameObject menuParentObject = new GameObject("Menus");
                _menuParent = menuParentObject.transform;
            }

            Menu[] menuPrefabs = { mainMenuPrefab, settingsMenuPrefab, creditsScreenPrefab };

            foreach (Menu prefab in menuPrefabs)
            {
                if (prefab != null)
                {
                    Menu menuInstance = Instantiate(prefab, _menuParent);
                    if (prefab != mainMenuPrefab)
                    {
                        menuInstance.gameObject.SetActive(false);
                    }
                    else
                    {
                        // open main menu
                    }
                }
            }
        }

    }
}