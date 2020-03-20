using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{
    // a specialized ScreenFader to launch the application
    [RequireComponent(typeof(ScreenFader))]
    public class SplashScreen : MonoBehaviour
    {
        // reference to the ScreenFader component
        [SerializeField]
        private ScreenFader _screenFader;

        // delay in seconds
        [SerializeField]
        private float delay = 1f;

        // assign the ScreenFader component
        private void Awake()
        {
            _screenFader = GetComponent<ScreenFader>();
        }

        // fade on the ScreenFader when we start
        private void Start()
        {
            _screenFader.FadeOn();
        }

        // fade off the ScreenFader and load the MainMenu
        public void FadeAndLoad()
        {
            StartCoroutine(FadeAndLoadRoutine());
        }

        // coroutine to fade off the ScreenFader and load the MainMenu
        private IEnumerator FadeAndLoadRoutine()
        {
            // wait for a delay
            yield return new WaitForSeconds(delay);

            // fade off
            _screenFader.FadeOff();

            // load the MainMenu scene
            LevelLoader.LoadMainMenuLevel();

            // wait for fade to complete
            yield return new WaitForSeconds(_screenFader.FadeOffDuration);

            // destroy the SplashScreen object
            Object.Destroy(gameObject);

        }
    }
}
