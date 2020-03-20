using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelManagement
{
    public class PauseMenu : Menu<PauseMenu>
    {
        // resumes the game and closes the pause menu
        public void OnResumePressed()
        {
            Time.timeScale = 1;
            base.OnBackPressed();
        }

        // unpauses and restarts the current level
        public void OnRestartPressed()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            base.OnBackPressed();
        }

        // unpauses and loads the MainMenu level
        public void OnMainMenuPressed()
        {
            Time.timeScale = 1;
            LevelLoader.LoadMainMenuLevel();
            MainMenu.Open();
        }

        // quits the application (does not work in Editor, build only)
        public void OnQuitPressed()
        {
            Application.Quit();
        }
    }
}
