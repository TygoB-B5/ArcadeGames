using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBrightness : MonoBehaviour
{
    [SerializeField] private float brightnessSensitivity, updateSpeed;
    private float brightness;
    private PlayerSpeed playerSpeed;
    private Color color = new Color(0, 0, 0);
    private Camera cam;

    void Awake()
    {
        playerSpeed = FindObjectOfType<PlayerSpeed>();
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        brightness = Mathf.Lerp(brightness, playerSpeed.speedDistance, updateSpeed * Time.deltaTime);
        color = new Color(brightness, brightness, brightness);
        cam.backgroundColor = color * brightnessSensitivity;
    }
}
