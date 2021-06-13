using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace General_Scripts
{
    public class SceneManager : MonoBehaviour
    {
        public static SceneManager manager;
        private int LastLoadedScene;
        private int _lastScene = 5;

        private void OnEnable()
        {
            manager = this;
        }

        private void OnDisable()
        {
            manager = null;
        }

        public void LoadScene(int id)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(id);
            LastLoadedScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        }

        public void ReloadScene()
        {
            LoadScene(LastLoadedScene);
        }

        public void LoadNext()
        {
            if (LastLoadedScene == _lastScene)
            {
                LoadScene(0);
                return;
            }
            LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
