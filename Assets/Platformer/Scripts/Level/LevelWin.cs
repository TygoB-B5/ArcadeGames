using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWin : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Win());
    }
    IEnumerator Win()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Menu");
    }
}
