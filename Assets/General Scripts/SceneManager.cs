using System;
using UnityEngine;

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
            LastLoadedScene = id;
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
            
            LoadScene(LastLoadedScene + 1);
        }
    }
}
