using UnityEngine;

namespace General_Scripts
{
    public class SceneManager : MonoBehaviour
    {
        public static int LastLoadedScene;

        private int _lastScene = 5;
        public void LoadScene(int id)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(id);
            LastLoadedScene = id;
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
