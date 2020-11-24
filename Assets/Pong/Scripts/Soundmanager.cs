using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundmanager : MonoBehaviour
{
    public AudioSource aud;
    public AudioClip[] audioClips;
    public void PlaySound(string sound)
    {
        if(sound == "bleep")
        {
            aud.PlayOneShot(audioClips[0]);
        }

        if (sound == "win")
        {
            aud.PlayOneShot(audioClips[1]);
        }

        if(sound == "difficultyraise")
        {
            aud.PlayOneShot(audioClips[2]);
        }

        if (sound == "powerup")
        {
            aud.PlayOneShot(audioClips[3]);
        }
    }
}
