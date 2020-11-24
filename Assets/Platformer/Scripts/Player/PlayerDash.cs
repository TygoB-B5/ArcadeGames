using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private PlayerJump playerJump;
    private PlayerInput playerInput;
    private PlayerEngine playerEngine;
    [SerializeField] private bool hasReset;
    [SerializeField] private float dashStrength, dashVerticalStrength;

    private void Awake()
    {
        playerJump = FindObjectOfType<PlayerJump>();
        playerInput = FindObjectOfType<PlayerInput>();
        playerEngine = FindObjectOfType<PlayerEngine>();
    }

    private void Update()
    {
        if (playerJump.isGrounded)
            hasReset = true;

        if (!playerJump.isGrounded && hasReset && playerInput.JumpDown)
            Dash();
    }

    private void Dash()
    {
        hasReset = false;
        playerEngine.rb.AddForce(Vector3.forward * playerInput.Horizontal * dashStrength, ForceMode.Impulse);
        playerEngine.rb.AddForce(Vector3.up * dashVerticalStrength, ForceMode.Impulse);
        Debug.Log("DASH");
    }
}
