using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Winmanager : MonoBehaviour
{
    public Text winText;
    private Transform ball;


    void Start()
    {
        winText.enabled = false;
        ball = GameObject.Find("Ball").transform;
    }

    void Update()
    {
        TestWin();
    }

    void TestWin()
    {
        if (ball.transform.position.x < -9)
        {
            Win(0);
            FindObjectOfType<Scoremanager>().AddPlayerPoint(0);
        }
        else if (ball.transform.position.x > 9)
        {
            FindObjectOfType<Scoremanager>().AddPlayerPoint(1);
            Win(1);
        }
    }

    void Win(int playerNumber)
    {
        winText.enabled = true;
        winText.text = "PLAYER " + (playerNumber + 1) + " WINS";

        FindObjectOfType<PongBall>().SetStartVelocity();
        ball.transform.position = new Vector3(0, 0, 0);
        ball.gameObject.SetActive(false);

        FindObjectOfType<Scoremanager>().ResetGeneral();
        FindObjectOfType<Soundmanager>().PlaySound("win");

        StartCoroutine(Reset());
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(3);
        ball.gameObject.SetActive(true);
        winText.enabled = false;
        yield return null;
    }
}
