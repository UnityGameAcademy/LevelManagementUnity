using System.Collections;
using System.Collections.Generic;
using System;

namespace LevelManagement.Data
{
	// to convert to JSON, the class must be tagged with System.Serializable
    [Serializable]
    public class SaveData
    {
    	// name for player, with default as "Player"
        public string playerName;
        private readonly string defaultPlayerName = "Player";

        // floats to store sound volume levels
        public float masterVolume;
        public float sfxVolume;
        public float musicVolume;

        // hash value calculated from the contents of SaveData
        public string hashValue;

        // constructor to initialize data
        public SaveData()
        {
            playerName = defaultPlayerName;
            masterVolume = 0f;
            sfxVolume = 0f;
            musicVolume = 0f;
            hashValue = String.Empty;
        }

    }
}
