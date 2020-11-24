using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBall : MonoBehaviour
{
    public Vector2 ballVelocity;
    const float maxBallYVelocity = 12.5f;
    private float ballXVelocity = 10;
    public float difficultyRaise = 0;

    private void Start()
    {
        SetStartVelocity();
    }

    public void SetStartVelocity()
    {
        //set begin velocity
        difficultyRaise = 0;
        if (Random.Range(0, 2) == 0)
            ballVelocity.x = ballXVelocity;
        else
            ballVelocity.x = -ballXVelocity;

        ballVelocity.y = Random.Range(-maxBallYVelocity, maxBallYVelocity);
    }

    void Update()
    {
        //updates position
        transform.position += new Vector3(ballVelocity.x, ballVelocity.y, 0) * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        {
            //WallCollision
            if (collision.transform.name == "Wall")
            {
                ballVelocity = new Vector2(ballVelocity.x, -ballVelocity.y);
            }
            
            if(collision.transform.CompareTag("Powerup"))
            {
                int playerNumber;

                if (ballVelocity.x > 0)
                    playerNumber = 0;
                else
                    playerNumber = 1;

                FindObjectOfType<Powerups>().UsePowerup(collision.gameObject, playerNumber);
            }

            //PlayerCollision
            for (int i = 0; i < 2; i++)
            {
                if (collision.transform.name == "Player" + i)
                {
                    float newYBallVelocity = Random.Range(-10.0f, 10.0f) + Mathf.Abs(ballVelocity.y / 2);
                    newYBallVelocity = Mathf.Clamp(newYBallVelocity, -maxBallYVelocity, maxBallYVelocity);
                    newYBallVelocity = -newYBallVelocity;
                    ballVelocity = new Vector3(-ballVelocity.x, newYBallVelocity);

                    FindObjectOfType<Soundmanager>().PlaySound("bleep");
                    FindObjectOfType<Scoremanager>().AddGeneralPoint();

                    RaiseDifficulty();
                }
            }
        }
    }

    void RaiseDifficulty()
    {
        if (FindObjectOfType<Scoremanager>().score % 10 == 0)
        {
            difficultyRaise += 1.5f;

            if (ballVelocity.x < 0)
            {
                ballVelocity = new Vector2(ballVelocity.x + -difficultyRaise, ballVelocity.y);
            }
            else
            {
                ballVelocity = new Vector2(ballVelocity.x + difficultyRaise, ballVelocity.y);
            }
            FindObjectOfType<Soundmanager>().PlaySound("difficultyraise");

            Debug.Log("Raising difficulty");
        }
    }
}
