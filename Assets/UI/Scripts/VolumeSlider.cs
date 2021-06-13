using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSlider : MonoBehaviour
{
    public AudioManager.Volume volumeType;
    public AudioManager audioManager;

    public void ChangeVolume(float vol)
    {
        audioManager.SetVolume(volumeType, vol);
        //*DING*!
    }
}
