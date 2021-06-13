using General_Scripts;
using UnityEngine;

public class Winscreen : MonoBehaviour
{
    public static Winscreen instance;

    void Start()
    {
        Winscreen.instance = this;
    }
    public void Next()
    {
        SceneManager.manager.LoadNext();
    }

    public void MainMenu()
    {
        SceneManager.manager.LoadScene(0);
    }
}
