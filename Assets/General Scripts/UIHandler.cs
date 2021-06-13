using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIHandler : MonoBehaviour
{
    public static UIHandler Handler;

    public GameObject winscreen;
    
    private void OnEnable()
    {
        Handler = this;
    }

    private void OnDisable()
    {
        Handler = null;
    }

    public void ShowWinScreen()
    {
        winscreen.gameObject.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
