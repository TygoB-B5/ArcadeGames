using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private GameObject[] paddles;
    private float[] paddleYPosition;
    const float paddleSpeed = 10;

    void Start()
    {
        paddleYPosition = new float[2];
        paddles = new GameObject[2];
        paddles[0] = GameObject.Find("Player0");
        paddles[1] = GameObject.Find("Player1");
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        for (int i = 0; i < 2; i++)
        {
            paddleYPosition[i] += VerticalInput(i) * Time.deltaTime;
            paddleYPosition[i] = Mathf.Clamp(paddleYPosition[i], -4, 4);
            paddles[i].transform.position = new Vector3(paddles[i].transform.position.x, paddleYPosition[i], 0);
        }
    }

    float VerticalInput(int playerNumber)
    {
        float verticalPlayerInput = 0;

        if (playerNumber == 0)
        {

            if (Input.GetKey(KeyCode.W))
                verticalPlayerInput = paddleSpeed;

            if (Input.GetKey(KeyCode.S))
                verticalPlayerInput = -paddleSpeed;
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
                verticalPlayerInput = paddleSpeed;

            if (Input.GetKey(KeyCode.DownArrow))
                verticalPlayerInput = -paddleSpeed;
        }
        return verticalPlayerInput;
    }

    public GameObject[] GetPaddleReference()
    {
        return paddles;
    }
}
