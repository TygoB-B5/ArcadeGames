using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    private int lives = 3;
    private int score = 0;
    public void Died()
    {
        lives--;
        FindObjectOfType<ArkanoidUi>().UpdateUi(lives);

        if(lives < 0)
        {
            Die();
        }
    }

    public void RaiseScore(int number)
    {
        score += number;
        FindObjectOfType<ArkanoidUi>().UpdateScore(score);
    }

    void Die()
    {
        SceneManager.LoadScene("Menu");
    }
}
