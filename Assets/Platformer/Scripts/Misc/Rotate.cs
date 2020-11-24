using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private Vector3 rotations;
    void Update()
    {
        transform.Rotate(rotations * Time.deltaTime);
    }
}
