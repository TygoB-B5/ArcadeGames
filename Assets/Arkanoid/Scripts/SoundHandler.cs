using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    public AudioClip[] clips;
    private AudioSource aud;

    private void Awake()
    {
        aud = GetComponent<AudioSource>();
    }

    public void PlaySound(string sound)
    {
        for (int i = 0; i < clips.Length; i++)
        {
            if (clips[i].name == sound)
            {
                aud.PlayOneShot(clips[i], 1);
                Debug.Log("Play sound: " + clips[i].name);
            }
        }
    }
}
