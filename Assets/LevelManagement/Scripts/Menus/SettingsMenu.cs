using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{
    public class SettingsMenu : Menu
    {
        private static SettingsMenu _instance;

        public static SettingsMenu Instance { get { return _instance; } }

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        private void OnDestroy()
        {
            if (_instance == this)
            {
                _instance = null;
            }
        }

        public override void OnBackPressed()
        {
            // or add extra logic here

            base.OnBackPressed();

            // add extra logic here
        }
    }
}