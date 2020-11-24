using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Win : MonoBehaviour
{
    private Text winText;

    private void Awake()
    {
        winText = GetComponentInChildren<Text>(true);
    }
    public void TestWin(int blockNumber)
    {
        if(blockNumber == 0)
        {
           StartCoroutine(WinGame());
        }
    }
    
    IEnumerator WinGame()
    {
        winText.enabled = true;
        FindObjectOfType<SoundHandler>().PlaySound("win");
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
