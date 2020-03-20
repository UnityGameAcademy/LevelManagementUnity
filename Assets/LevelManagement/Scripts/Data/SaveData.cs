using System.Collections;
using System.Collections.Generic;
using System;

namespace LevelManagement.Data
{
    [Serializable]
    public class SaveData
    {
        public string playerName;
        private readonly string defaultPlayerName = "Player";

        public float masterVolume;
        public float sfxVolume;
        public float musicVolume;

        public SaveData()
        {
            playerName = defaultPlayerName;
            masterVolume = 0f;
            sfxVolume = 0f;
            musicVolume = 0f;
        }

    }
}
