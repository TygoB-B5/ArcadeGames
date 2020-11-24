using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerEngine : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerSpeed playerSpeed;
    public Rigidbody rb { get; set; }

    void Awake()
    {
        playerInput = FindObjectOfType<PlayerInput>();
        playerSpeed = FindObjectOfType<PlayerSpeed>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.transform.position += transform.forward * playerInput.Horizontal * playerSpeed.speed * Time.deltaTime;
    }
}
