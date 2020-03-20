using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text;
using System.Security.Cryptography;

namespace LevelManagement.Data
{
    public class JsonSaver
    {
        // default filename
        private static readonly string _filename = "saveData1.sav";

        // returns filename with fullpath
        public static string GetSaveFilename()
        {
            return Application.persistentDataPath + "/" + _filename;
        }

        // convert the SaveData to JSON format and write to disk
        public void Save(SaveData data)
        {
            // reset the hash value
            data.hashValue = String.Empty;

            // convert the data to a JSON-formatted string
            string json = JsonUtility.ToJson(data);

            // generate a hash value as a hexidecimal string and store in SaveData 
            data.hashValue = GetSHA256(json);

            // convert the data to JSON again (to add the hash string)
            json = JsonUtility.ToJson(data);

            // reference to filename with full path
            string saveFilename = GetSaveFilename();

            // create the file
            FileStream filestream = new FileStream(saveFilename, FileMode.Create);

            // open file, write to file and close file
            using (StreamWriter writer = new StreamWriter(filestream))
            {
                writer.Write(json);
            }
        }

        // load the data from disk and overwrite the contents of SaveData object
        public bool Load(SaveData data)
        {
            // reference to filename
            string loadFilename = GetSaveFilename();

            // only run if we find the filename on disk
            if (File.Exists(loadFilename))
            {
                // open the file and prepare to read
                using (StreamReader reader = new StreamReader(loadFilename))
                {
                    // read the file as a string
                    string json = reader.ReadToEnd();

                    // verify the data using the hash value
                    if (CheckData(json))
                    {
                        // read the data and overwrite the save data if the hash is valid
                        JsonUtility.FromJsonOverwrite(json, data);
                    }
                    // hash is invalid
                    else
                    {
                        Debug.LogWarning("JSONSAVER Load: invalid hash.  Aborting file read...");
                    }
                }
                return true;
            }
            return false;
        }

        // verifies if a save file has a valid hash
        private bool CheckData(string json)
        {
            // create a temporary SaveData object to store the data
            SaveData tempSaveData = new SaveData();

            // read the data into the temp SaveData object
            JsonUtility.FromJsonOverwrite(json, tempSaveData);

            // grab the saved hash value and reset
            string oldHash = tempSaveData.hashValue;
            tempSaveData.hashValue = String.Empty;

            // generate a temporary JSON file with the hash reset to empty
            string tempJson = JsonUtility.ToJson(tempSaveData);

            // calculate the hash 
            string newHash = GetSHA256(tempJson);

            // return whether the old and new hash values match
            return (oldHash == newHash);
        }

        // deletes the save file from disk (useful for testing)
        public void Delete()
        {
            File.Delete(GetSaveFilename());
        }

        // converts an array of bytes into a hexidecimal string 
        public string GetHexStringFromHash(byte[] hash)
        {
            // placeholder string
            string hexString = String.Empty;

            // convert each byte to a two-digit hexidecimal number and add to placeholder
            foreach (byte b in hash)
            {
                hexString += b.ToString("x2");
            }

            // return the concatenated hexidecimal string
            return hexString;
        }

        // converts a string into a SHA256 hash value
        private string GetSHA256(string text)
        {
            // conver the text into an array of bytes
            byte[] textToBytes = Encoding.UTF8.GetBytes(text);

            // create a temporary SHA256Managed instance
            SHA256Managed mySHA256 = new SHA256Managed();

            // calculate the hash value as an array of bytes
            byte[] hashValue = mySHA256.ComputeHash(textToBytes);

            // convert to a hexidecimal string and return
            return GetHexStringFromHash(hashValue);
        }
    }
}
