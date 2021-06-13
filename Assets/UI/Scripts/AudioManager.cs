using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public float masterVolume = 1f;
    public float musicVolume = 1f;
    public float sfxVolume = 1f;

    public AudioMixer mixer;
    public static AudioManager instance;

    public enum Volume{master, music, sfx, bit, ui};

    void Awake()
    {
        if(AudioManager.instance == null)
        {
            AudioManager.instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(gameObject);
    }
    
    
    private float RemapVolumePercent(float percent)
    {
        float newValue = 0f;
        percent = Mathf.Clamp(percent, 0.001f, 2f);
        newValue = Mathf.Log(percent) * 20;
        return newValue;
    }

    public float GetVolume(Volume volType)
    {
        switch(volType)
        {
            case Volume.master:
                return masterVolume;
            
            case Volume.music:
                return musicVolume;
            
            case Volume.sfx:
                return sfxVolume;
            
            default:
                return 0;
        }
    }

    public void SetMusicVolume(float newVol)
    {
        musicVolume = newVol;
        mixer.SetFloat("MusicVolume", RemapVolumePercent(newVol)); 
    }

    public void SetSFXVolume(float newVol)
    {
        sfxVolume = newVol;
        mixer.SetFloat("SFXVolume", RemapVolumePercent(newVol));
    }

    public void SetMasterVolume(float newVol)
    {
        masterVolume = newVol;
        mixer.SetFloat("MasterVolume", RemapVolumePercent(newVol));
    }

    public void SetVolume(Volume category, float vol)
    {
        switch(category)
        {
            case Volume.master:
                SetMasterVolume(vol);
                break;

            case Volume.sfx:
                SetSFXVolume(vol);
                break;

            case Volume.music:
                SetMusicVolume(vol);
                break;

            default:
                break;
        }
    }

    public void UpdateAllVolumes()
    {
        SetMasterVolume(masterVolume);
        SetMusicVolume(musicVolume);
        SetSFXVolume(sfxVolume);
    }
}
