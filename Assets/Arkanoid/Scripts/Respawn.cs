using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    void Update()
    {
        DetectOutOfBound();
    }

    void DetectOutOfBound()
    {
        if(transform.position.y < -5.5f)
        {
            ResetBlock();
        }
    }

    void ResetBlock()
    {
        FindObjectOfType<Paddlecontroller>().transform.position = new Vector3(0, -4, 0);
        transform.position = new Vector3(0, -3.5f, 0);
        FindObjectOfType<ScoreManager>().Died();
        FindObjectOfType<SoundHandler>().PlaySound("win");
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1;
    }
}
