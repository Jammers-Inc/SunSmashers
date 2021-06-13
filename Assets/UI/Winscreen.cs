using System;
using General_Scripts;
using UnityEngine;

public class Winscreen : MonoBehaviour
{
    public void Next()
    {
        SceneManager.manager.LoadNext();
    }

    public void MainMenu()
    {
        SceneManager.manager.LoadScene(0);
    }
}
