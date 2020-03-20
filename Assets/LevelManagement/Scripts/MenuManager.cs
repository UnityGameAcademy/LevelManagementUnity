using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

namespace LevelManagement
{
    // class for managing the Menus
    public class MenuManager : MonoBehaviour
    {

        // define all Menu prefabs here and assign in the Inspector
        [SerializeField]
        private  MainMenu mainMenuPrefab;
        [SerializeField]
        private SettingsMenu settingsMenuPrefab;
        [SerializeField]
        private CreditsScreen creditsScreenPrefab;
        [SerializeField]
        private GameMenu gameMenuPrefab;
        [SerializeField]
        private PauseMenu pauseMenuPrefab;
        [SerializeField]
        private WinScreen winScreenPrefab;

        // transform for organizing your Menus, defaults to Menus object
        [SerializeField]
        private Transform _menuParent;

        // stack for tracking our active Menus
        private Stack<Menu> _menuStack = new Stack<Menu>();

        // single instance
        private static MenuManager _instance;
        public static MenuManager Instance { get { return _instance; } }


        private void Awake()
        {
            // self-destruct if a MenuManager instance already exists
            if (_instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                // otherwise, assign this object as the Singleton instance
                _instance = this;

                // initialize Menus and make this GameObject persistent
                InitializeMenus();
                DontDestroyOnLoad(gameObject);
            }
        }

        // remove Singleton instance if this object is destroyed
        private void OnDestroy()
        {
            if (_instance == this)
            {
                _instance = null;
            }
        }

        // create the Menus at the start of the game
        private void InitializeMenus()
        {

            // generate a default parent object if none specified
            if (_menuParent == null)
            {
                GameObject menuParentObject = new GameObject("Menus");
                _menuParent = menuParentObject.transform;
            }

            // mark the parent object as persistent
            DontDestroyOnLoad(_menuParent.gameObject);

            // use reflection to locate the Menu prefab fields defined at the top
            BindingFlags myFlags = BindingFlags.Instance | BindingFlags.NonPublic | 
                                               BindingFlags.DeclaredOnly;
            FieldInfo[] fields = this.GetType().GetFields(myFlags);

            // loop through the fields
            foreach (FieldInfo field in fields)
            {
                // locate the prefab from each field
                Menu prefab = field.GetValue(this) as Menu;

                // if we find a prefab...
                if (prefab != null)
                {
                    // ... instantiate it
                    Menu menuInstance = Instantiate(prefab, _menuParent);

                    // disable the Menu object unless it is the MainMenu
                    if (prefab != mainMenuPrefab)
                    {
                        menuInstance.gameObject.SetActive(false);
                    }
                    else
                    {
                        OpenMenu(menuInstance);
                    }
                }
            }
        }

        // open a Menu and add to the Menu stack
        public void OpenMenu(Menu menuInstance)
        {
            if (menuInstance == null)
            {
                Debug.Log("MENUMANAGER OpenMenu ERROR: invalid menu");
                return;
            }

            // disable all of the previous menus in the stack
            if (_menuStack.Count > 0)
            {
                foreach (Menu menu in _menuStack)
                {
                    menu.gameObject.SetActive(false);
                }
            }

            // activate the Menu and add to the top of the Menu stack
            menuInstance.gameObject.SetActive(true);
            _menuStack.Push(menuInstance);
        }

        // close a Menu and remove it from the Menu stack
        public void CloseMenu()
        {
            // if the stack is empty, do nothing
            if (_menuStack.Count == 0)
            {
                Debug.LogWarning("MENUMANAGER CloseMenu ERROR: No menus in stack!");
                return;
            }

            // remove the top Menu and disable
            Menu topMenu = _menuStack.Pop();
            topMenu.gameObject.SetActive(false);

            // enable the next Menu revealed at the top of the Menu stack
            if (_menuStack.Count > 0)
            {
                Menu nextMenu = _menuStack.Peek();
                nextMenu.gameObject.SetActive(true);
            }
        }
    }
}