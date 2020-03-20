using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{
    public class GameMenu : Menu<GameMenu>
    {
        // pauses the game and opens the pause menu
        public void OnPausePressed()
        {
            Time.timeScale = 0;

            PauseMenu.Open();
        }

    }
}
