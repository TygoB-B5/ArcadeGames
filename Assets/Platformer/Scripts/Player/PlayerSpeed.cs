using UnityEngine;

public class PlayerSpeed : MonoBehaviour
{
    public float defaultSpeed { get; private set; } = 15;
    public float speedDistance { get; private set; }
    private float _speed;
    public float speed
    {
        get { return _speed; }
        set { _speed = Mathf.Clamp(value, -defaultSpeed, defaultSpeed); }
    }

    private void Start()
    {
        speed = defaultSpeed;
    }

    private void FixedUpdate()
    {
        CalculateSpeed();
    }

    private Vector3 oldPos;
    private void CalculateSpeed()
    {
        speedDistance = Vector3.Distance(oldPos, transform.position) * 1.5f;

        oldPos = transform.position;
    }
}
