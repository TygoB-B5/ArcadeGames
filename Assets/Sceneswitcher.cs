using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneswitcher : MonoBehaviour
{
    public void Pong()
    {
        SceneManager.LoadScene("Pong");
        Time.timeScale = 1;
    }

    public void Arkanoid()
    {
        SceneManager.LoadScene("Arkanoid");
        Time.timeScale = 1;
    }

    public void Platformer()
    {
        SceneManager.LoadScene("Platformer0");
        Time.timeScale = 1;
    }

}
