using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamecontroller : MonoBehaviour
{
    private GameObject ball;
    [SerializeField] private int blockNumber;
    void Start()
    {
        Time.timeScale = 0;

        ball = GameObject.Find("Ball");

        blockNumber = 170;
    }

    public void RemoveBlock()
    {
        blockNumber--;
        FindObjectOfType<ScoreManager>().RaiseScore(10);
        FindObjectOfType<Win>().TestWin(blockNumber);
        FindObjectOfType<Huebackground>().UpdateColor(blockNumber);
        FindObjectOfType<Ball>().IncreaseSpeed(0.05f);
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        ball.SetActive(true);
    }
}
