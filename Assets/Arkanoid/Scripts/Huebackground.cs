    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huebackground : MonoBehaviour
{
    private Camera cam;
    private Color color;
    private void Start()
    {
        cam = GetComponent<Camera>();
        color.g = 0.30f;
    }

    public void UpdateColor(int blockNumber)
    {
        float b = (float)blockNumber / 170;
        float r = 1 - b;
        color.b = b;
        color.r = r;
        cam.backgroundColor = color;
    }
}
