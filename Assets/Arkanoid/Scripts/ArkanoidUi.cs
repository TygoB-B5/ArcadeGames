using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ArkanoidUi : MonoBehaviour
{
    public Text livesText;
    public Text scoreText;

    public void UpdateUi(int lives)
    {
        livesText.text = "Lives: " + lives.ToString();
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
