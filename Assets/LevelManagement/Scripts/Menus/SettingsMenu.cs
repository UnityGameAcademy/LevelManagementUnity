using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LevelManagement.Data;

namespace LevelManagement
{
    public class SettingsMenu : Menu<SettingsMenu>
    {
        [SerializeField]
        private Slider _masterVolumeSlider;

        [SerializeField]
        private Slider _sfxVolumeSlider;

        [SerializeField]
        private Slider _musicVolumeSlider;

        private DataManager _dataManager;

		protected override void Awake()
		{
            base.Awake();
            _dataManager = Object.FindObjectOfType<DataManager>();
		}

		private void Start()
		{
            LoadData();
		}

		public void OnMasterVolumeChanged(float volume)
        {
            if (_dataManager != null)
            {
                _dataManager.MasterVolume = volume;
            }
            //PlayerPrefs.SetFloat("MasterVolume", volume);
        }

        public void OnSFXVolumeChanged(float volume)
        {
            if (_dataManager != null)
            {
                _dataManager.SfxVolume = volume;
            }
            //PlayerPrefs.SetFloat("SFXVolume", volume);
        }

        public void OnMusicVolumeChanged(float volume)
        {
            if (_dataManager != null)
            {
                _dataManager.MusicVolume = volume;
            }
            //PlayerPrefs.SetFloat("MusicVolume", volume);
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
            //PlayerPrefs.Save();
        }

        public void LoadData()
        {
            if (_dataManager == null || _masterVolumeSlider == null ||
                _sfxVolumeSlider == null || _musicVolumeSlider == null)
            {
                return;
            }

            _masterVolumeSlider.value = _dataManager.MasterVolume;
            _sfxVolumeSlider.value = _dataManager.SfxVolume;
            _musicVolumeSlider.value = _dataManager.MusicVolume;

            //_masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
            //_sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume");
            //_musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        }
    }
}