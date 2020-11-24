using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Scoremanager : MonoBehaviour
{
    public float score = 0;
    private float[] playerScore;

    public Text scoreText;
    public Text[] playerScoreText;

    private void Start()
    {
        playerScore = new float[2];
    }
    public void AddGeneralPoint()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void ResetGeneral()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    public void AddPlayerPoint(int playerNumber)
    {
        playerScore[playerNumber]++;
        playerScoreText[playerNumber].text = playerScore[playerNumber].ToString();

        TestForVictory(playerNumber);
    }

    void TestForVictory(int playerNumber)
    {
        if(playerScore[playerNumber] == 10)
        {
            for (int i = 0; i< 2; i++)
            {
                Time.timeScale = 0;
                playerScore[i] = 0;
            }
        }
    }
}
