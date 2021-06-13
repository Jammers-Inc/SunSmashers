using UnityEngine;

namespace General_Scripts
{
    public class SceneManager : MonoBehaviour
    {
        public void LoadScene(int id)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(id);
        }
    }
}
