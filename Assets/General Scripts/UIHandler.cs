using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public static UIHandler Handler;

    private GameObject[] menus;
    private void OnEnable()
    {
        Handler = this;
    }

    private void OnDisable()
    {
        Handler = null;
    }

    public void ShowMainMenu()
    {
        Instantiate(menus[0]);
    }
    
    public void ShowLevelMenu()
    {
        
    }

    public void ShowHUD()
    {
        
    }

    public void ShowWinScreen()
    {
        
    }
}
