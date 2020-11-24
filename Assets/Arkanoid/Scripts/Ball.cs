using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speedX, speedY;
    private Gamecontroller gameController;

    void Start()
    {
        gameController = FindObjectOfType<Gamecontroller>();
        SetRandomSpeed();
    }

    void Update()
    {
        MoveBall();
    }

    void SetRandomSpeed()
    {
        speedX = Random.Range(-4f, 4f);
        speedY = 5;
    }

    public void IncreaseSpeed(float speed)
    {
        if (speedY < 0)
            speed = -speed;
        speedY += speed;
        speedY = Mathf.Clamp(speedY, -12.5f, 12.5f);
    }

    void MoveBall()
    {
        transform.position += new Vector3(speedX, speedY, 0) * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            CheckForHitSide(collision);

            FindObjectOfType<SoundHandler>().PlaySound("bleep");

            Destroy(collision.gameObject, 0);
            gameController.RemoveBlock();
        }
        else if(collision.gameObject.tag == "PowerupBlock")
        {
            CheckForHitSide(collision);

            collision.gameObject.GetComponentInChildren<Powerup>().SpawnPowerup();
            Destroy(collision.gameObject, 0);
            gameController.RemoveBlock();
        }
        else if (collision.gameObject.tag == "Player")
        {
            speedX = Random.Range(-5f, 5f);
            speedY = -speedY;
        }

        else if (collision.gameObject.tag == "Wall")
        {
            speedX = -speedX;
        }
        else if (collision.gameObject.tag == "Ceiling")
        {
            speedY = -speedY;
        }
    }

    void CheckForHitSide(Collision col)
    {
        if(col.gameObject.transform.position.y - col.gameObject.transform.localScale.y / 2 + 0.02f < transform.position.y && col.gameObject.transform.position.y + col.gameObject.transform.localScale.y / 2 + 0.02f > transform.position.y)
        {
            speedX = -speedX;
        }
        else
        {
            speedY = -speedY;
        }
    }
}
