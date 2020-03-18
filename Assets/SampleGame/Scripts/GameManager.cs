using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.SceneManagement;

namespace SampleGame
{
    public class GameManager : MonoBehaviour
    {
        // reference to player
        private ThirdPersonCharacter _player;

        // reference to goal effect
        private GoalEffect _goalEffect;

        // reference to player
        private Objective _objective;

        private bool _isGameOver;
        public bool IsGameOver { get { return _isGameOver; } }


        [SerializeField]
        private string nextLevelName = "Level1";

        [SerializeField]
        private int nextLevelIndex;

        private static GameManager _instance;
        public static GameManager Instance { get { return _instance; } }

        // initialize references
        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }

            _player = Object.FindObjectOfType<ThirdPersonCharacter>();
            _objective = Object.FindObjectOfType<Objective>();
            _goalEffect = Object.FindObjectOfType<GoalEffect>();
        }

        private void OnDestroy()
        {
            if (_instance == this)
            {
                _instance = null;
            }
        }

        // end the level
        public void EndLevel()
        {
            if (_player != null)
            {
                // disable the player controls
                ThirdPersonUserControl thirdPersonControl =
                    _player.GetComponent<ThirdPersonUserControl>();

                if (thirdPersonControl != null)
                {
                    thirdPersonControl.enabled = false;
                }

                // remove any existing motion on the player
                Rigidbody rbody = _player.GetComponent<Rigidbody>();
                if (rbody != null)
                {
                    rbody.velocity = Vector3.zero;
                }

                // force the player to a stand still
                _player.Move(Vector3.zero, false, false);
            }

            // check if we have set IsGameOver to true, only run this logic once
            if (_goalEffect != null && !_isGameOver)
            {
                _isGameOver = true;
                _goalEffect.PlayEffect();
                LoadNextLevel();
            }
        }

        private void LoadLevel(string levelName)
        {
            if (Application.CanStreamedLevelBeLoaded(levelName))
            {
                SceneManager.LoadScene(levelName);
            }
            else
            {
                Debug.LogWarning("GAMEMANAGER LoadLevel Error: invalid scene specified!");
            }
        }

        private void LoadLevel(int levelIndex)
        {
            if (levelIndex >= 0 && levelIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(levelIndex);
            }
            else
            {
                Debug.LogWarning("GAMEMANAGER LoadLevel Error: invalid scene specified!"); 
            }
        }

        public void ReloadLevel()
        {
            LoadLevel(SceneManager.GetActiveScene().name);
        }

        public void LoadNextLevel()
        {
            //Scene currentScene = SceneManager.GetActiveScene();
            //int currentSceneIndex = currentScene.buildIndex;
            //int nextSceneIndex = currentSceneIndex + 1;
            //int totalSceneCount = SceneManager.sceneCountInBuildSettings;
            //nextSceneIndex = nextLevelIndex % totalSceneCount;

            int nextSceneIndex = (SceneManager.GetActiveScene().buildIndex + 1) 
                % SceneManager.sceneCountInBuildSettings;
            LoadLevel(nextSceneIndex);
        }

        // check for the end game condition on each frame
        private void Update()
        {
            if (_objective != null && _objective.IsComplete)
            {
                EndLevel();
            }
        }
    }
}