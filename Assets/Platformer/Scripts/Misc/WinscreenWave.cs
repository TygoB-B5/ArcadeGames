using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WinscreenWave : MonoBehaviour
{
    private float timer = 0;
    private float yPos;
    [SerializeField] private float waveLength;

    private void Start()
    {
        yPos = transform.position.y;
    }

    void Update()
    {
        timer += 1 * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, yPos + Mathf.Sin(timer) * waveLength, transform.position.z);
    }
}
