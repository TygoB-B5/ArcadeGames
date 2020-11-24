using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerJump : MonoBehaviour
{
    private bool isCharging = false;
    public bool isJumping { get; private set; }
    public bool isGrounded { get; private set; }
    private float timer;

    [SerializeField] private float jumpDefaultForce, jumpChargeTime, maxChargeForce;

    private PlayerInput playerInput;
    private PlayerSpeed playerSpeed;
    private PlayerEngine playerEngine;

    void Awake()
    {
        playerInput = FindObjectOfType<PlayerInput>();
        playerSpeed = FindObjectOfType<PlayerSpeed>();
        playerEngine = FindObjectOfType<PlayerEngine>();
    }

    private void Update()
    {
        HandleJump();
    }

    private void HandleJump()
    {
        if (!isGrounded)
            return;

        ChargeJump();
    }

    private void ChargeJump()
    {
        if (playerInput.JumpDown)
        {
            isCharging = true;
        }

        if (isCharging)
        {
            UpdateTimer();
            SetYScale(-((timer + 0.05f) / maxChargeForce) + 1.1f);
            SetPlayerSpeed(playerSpeed.defaultSpeed / 2);
        }

        if (!playerInput.Jump && isCharging)
        {
            isCharging = false;
            Jump();
            SetYScale(1);
            SetPlayerSpeed(playerSpeed.defaultSpeed);

            timer = 0;
        }
    }

    void SetPlayerSpeed(float s)
    {
        playerSpeed.speed = s;
    }

    void Jump()
    {
        isJumping = true;
        playerEngine.rb.AddForce(Vector3.up * (jumpDefaultForce + timer), ForceMode.Impulse);
        playerEngine.rb.transform.Translate(Vector3.up * 0.5f);
    }

    void UpdateTimer()
    {
        timer += jumpChargeTime * Time.deltaTime;
        timer = Mathf.Clamp(timer, 0, maxChargeForce);
    }

    void SetYScale(float yScale)
    {
        transform.localScale = new Vector3(1, yScale, 1);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
        isJumping = false;
    }
}
