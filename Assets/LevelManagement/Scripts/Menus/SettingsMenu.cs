using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

		protected override void Awake()
		{
            base.Awake();
            LoadPreferences();
		}

		public void OnMasterVolumeChanged(float volume)
        {
            PlayerPrefs.SetFloat("MasterVolume", volume);
        }

        public void OnSFXVolumeChanged(float volume)
        {
            PlayerPrefs.SetFloat("SFXVolume", volume);
        }

        public void OnMusicVolumeChanged(float volume)
        {
            PlayerPrefs.SetFloat("MusicVolume", volume);
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
            PlayerPrefs.Save();
        }

        public void LoadPreferences()
        {
            _masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
            _sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume");
            _musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        }
    }
}