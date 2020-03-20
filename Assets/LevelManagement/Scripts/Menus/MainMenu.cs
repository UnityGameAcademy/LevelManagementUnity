 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SampleGame;
using UnityEngine.UI;
using LevelManagement.Data;

namespace LevelManagement
{
    public class MainMenu : Menu<MainMenu>
    {
        [SerializeField]
        private float _playDelay = 0.5f;

        [SerializeField]
        private TransitionFader startTransitionPrefab;

        private DataManager _dataManager;

        [SerializeField]
        private InputField _inputField;

		protected override void Awake()
		{
            base.Awake();
            _dataManager = Object.FindObjectOfType<DataManager>();
		}

		private void Start()
		{
            LoadData();
		}

        private void LoadData()
        {
            if (_dataManager != null && _inputField != null)
            {
                _dataManager.Load();
                _inputField.text = _dataManager.PlayerName;
            }
        }

        public void OnPlayerNameValueChanged(string name)
        {
            if (_dataManager != null)
            {
                _dataManager.PlayerName = name;
            }
        }

        public void OnPlayerNameEndEdit()
        {
            if (_dataManager != null)
            {
                _dataManager.Save();
            }
        }

		public void OnPlayPressed()
        {
            StartCoroutine(OnPlayPressedRoutine());
        }

        private IEnumerator OnPlayPressedRoutine()
        {
            TransitionFader.PlayTransition(startTransitionPrefab);
            LevelLoader.LoadNextLevel();
            yield return new WaitForSeconds(_playDelay);
            GameMenu.Open();
        }

        public void OnSettingsPressed()
        {

            SettingsMenu.Open();
        }

        public void OnCreditsPressed()
        {
            CreditsScreen.Open();
        }

        public override void OnBackPressed()
        {
            Application.Quit();
        }

    }
}