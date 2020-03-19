using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{
    [RequireComponent(typeof(ScreenFader))]
    public class SplashScreen : MonoBehaviour
    {
        [SerializeField]
        private ScreenFader _screenFader;

        [SerializeField]
        private float delay = 1f;

        private void Awake()
        {
            _screenFader = GetComponent<ScreenFader>();
        }

        private void Start()
        {
            _screenFader.FadeOn();
        }

        public void FadeAndLoad()
        {
            StartCoroutine(FadeAndLoadRoutine());
        }

        private IEnumerator FadeAndLoadRoutine()
        {
            
            yield return new WaitForSeconds(delay);
            _screenFader.FadeOff();
            LevelLoader.LoadMainMenuLevel();

            yield return new WaitForSeconds(_screenFader.FadeOnDuration);

            Object.Destroy(gameObject);

        }
    }
}
