 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SampleGame;
using UnityEngine.UI;
using LevelManagement.Data;

namespace LevelManagement
{
    // controls the MainMenu screen
    public class MainMenu : Menu<MainMenu>
    {
        // delay before we play the game
        [SerializeField]
        private float _playDelay = 0.5f;

        // reference to transition prefab
        [SerializeField]
        private TransitionFader startTransitionPrefab;

        // reference to DataManager
        private DataManager _dataManager;

        // reference to UI.InputField for PlayerName
        [SerializeField]
        private InputField _inputField;

        // initialize
		protected override void Awake()
		{
            base.Awake();
            _dataManager = Object.FindObjectOfType<DataManager>();
		}

        // load the save data
		private void Start()
		{
            LoadData();
		}

        // load the saved data and retrieve the PlayerName
        private void LoadData()
        {
            if (_dataManager != null && _inputField != null)
            {
                _dataManager.Load();
                _inputField.text = _dataManager.PlayerName;
            }
        }

        // save the PlayerName as we type into the InputField
        public void OnPlayerNameValueChanged(string name)
        {
            if (_dataManager != null)
            {
                _dataManager.PlayerName = name;
            }
        }

        // save the data to disk when done editing
        public void OnPlayerNameEndEdit()
        {
            if (_dataManager != null)
            {
                _dataManager.Save();
            }
        }

        // launch the first game level
		public void OnPlayPressed()
        {
            StartCoroutine(OnPlayPressedRoutine());
        }

        // start the transition and play the first level
        private IEnumerator OnPlayPressedRoutine()
        {
            TransitionFader.PlayTransition(startTransitionPrefab);
            LevelLoader.LoadNextLevel();
            yield return new WaitForSeconds(_playDelay);
            GameMenu.Open();
        }

        // open the SettingsMenu
        public void OnSettingsPressed()
        {

            SettingsMenu.Open();
        }

        // open the Credits Screen
        public void OnCreditsPressed()
        {
            CreditsScreen.Open();
        }

        // quit the application
        public override void OnBackPressed()
        {
            Application.Quit();
        }

    }
}