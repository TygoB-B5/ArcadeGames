using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Createfield : MonoBehaviour
{
    public GameObject block;
    public GameObject powerupBlock;

    void Start()
    {
        StartCoroutine(Create());
    }

    IEnumerator Create()
    {
        for (int x = -8; x < 9; x++)
        {
            for (float y = -2; y < 3; y += 0.5f)
            {
                if (y % 1 == 0)
                {
                    yield return new WaitForSecondsRealtime(0.01f);
                    Instantiate(GetBlock(), new Vector3(x - 0.25f, y, 0), Quaternion.Euler(0, 0, 0), transform);
                }
                else
                {
                    yield return new WaitForSecondsRealtime(0.01f);
                    Instantiate(GetBlock(), new Vector3(x - 0.25f + 0.5f, y, 0), Quaternion.Euler(0, 0, 0), transform);
                }
            }
        }

        FindObjectOfType<Gamecontroller>().StartGame();
    }

    public GameObject GetBlock()
    {
        GameObject blockType;
        float randomNumber = Random.Range(0, 100);

        if(randomNumber <= 5)
        {
            blockType = powerupBlock;
        } else
        {
            blockType = block;
        }

        return blockType;
    }
}
