using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{ 
    public class SettingsMenu : Menu<SettingsMenu>
    {
        public void OnMasterVolumeChanged(float volume)
        {
            Debug.Log("Master Volume = " + volume);
        }

        public void OnSFXVolumeChanged(float volume)
        {
            
        }

        public void OnMusicVolumeChanged(float volume)
        {
            
        }

        public override void OnBackPressed()
        {
            // or add extra logic here

            base.OnBackPressed();

            // add extra logic here
        }
    }
}