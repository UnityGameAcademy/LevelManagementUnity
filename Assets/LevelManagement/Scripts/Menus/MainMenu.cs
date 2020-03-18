using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SampleGame;

namespace LevelManagement
{
    public class MainMenu : Menu
    {
        public void OnPlayPressed()
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.LoadNextLevel();
            }
        }

        public void OnSettingsPressed()
        {
            Menu settingsMenu = transform.parent.Find("SettingsMenu(Clone)").GetComponent<Menu>();
            if (MenuManager.Instance != null && settingsMenu != null)
            {
                MenuManager.Instance.OpenMenu(settingsMenu);
            }
        }

        public void OnCreditsPressed()
        {

            Menu creditsScreen = transform.parent.Find("CreditsScreen(Clone)").GetComponent<Menu>();
            if (MenuManager.Instance != null && creditsScreen != null)
            {
                MenuManager.Instance.OpenMenu(creditsScreen);
            }
        }

        public override void OnBackPressed()
        {
            Application.Quit();
        }
    }
}