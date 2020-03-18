using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SampleGame;

namespace LevelManagement
{
    [RequireComponent(typeof(Canvas))]
    public class Menu : MonoBehaviour
    {
        public void OnPlayPressed()
        {
            GameManager gameManager = Object.FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.LoadNextLevel();
            }
        }

        public void OnSettingsPressed()
        {
            
        }

        public void OnCreditsPressed()
        {
            
        }

        public void OnBackPressed()
        {
            
        }

    }
}
