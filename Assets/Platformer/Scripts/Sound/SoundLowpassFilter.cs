using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLowpassFilter : MonoBehaviour
{
    private AudioLowPassFilter lowpassFilter;
    private PlayerSpeed playerSpeed;
    private float startFrequency, updateValue;
    [SerializeField] private float updateSpeed;
    [SerializeField] private float multiplier;

    private void Awake()
    {
        GetReferenes();
        startFrequency = lowpassFilter.cutoffFrequency;
        FindObjectOfType<SoundPlayer>().OnSceneChange += GetReferenes;
    }

    private void GetReferenes()
    {
        playerSpeed = FindObjectOfType<PlayerSpeed>();
        lowpassFilter = GetComponent<AudioLowPassFilter>();
    }

    void Update()
    {
        updateValue = Mathf.Lerp(updateValue, playerSpeed.speedDistance, updateSpeed * Time.deltaTime);
        lowpassFilter.cutoffFrequency = startFrequency + updateValue * (multiplier * 100);
    }
}
