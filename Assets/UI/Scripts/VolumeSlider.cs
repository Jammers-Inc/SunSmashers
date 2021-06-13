using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public AudioManager.Volume volumeType;
    public AudioManager audioManager;

    public Slider slider;
    
    private void Start()
    {
        audioManager = AudioManager.instance;
        slider.value = audioManager.masterVolume;
    }

    public void ChangeVolume(float vol)
    {
        audioManager.SetVolume(volumeType, vol);
        //*DING*!
    }
}
