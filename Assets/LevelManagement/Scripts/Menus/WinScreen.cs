using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelManagement
{
    // shown when player completes the level
    public class WinScreen : Menu<WinScreen>
    {
        // advance to the next level
        public void OnNextLevelPressed()
        {
            base.OnBackPressed();
            LevelLoader.LoadNextLevel();
        }

        // restart the current level
        public void OnRestartPressed()
        {
            base.OnBackPressed();
            LevelLoader.ReloadLevel();
        }

        // return to MainMenu scene
        public void OnMainMenuPressed()
        {
            LevelLoader.LoadMainMenuLevel();
            MainMenu.Open();
        }
    }
}
