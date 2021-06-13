using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioSource[] sources;
    
    public void PlayGrabSound()
    {
        Play(0);
    }

    public void PlayFailSound()
    {
        Play(1);
    }

    public void PlayMissedSound()
    {
        Play(2);
    }

    public void PlayReleaseGrapSound()
    {
        Play(3);
    }

    public void PlayEnterSunSound()
    {
        Play(4);
    }

    public void PlayFlySound()
    {
        Play(5);
    }

    public void StopFlySound()
    {
        sources[5].Stop();
    }

    public void Play(int id)
    {
        sources[id].Play();
    }
}
