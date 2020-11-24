using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    public GameObject powerup;

    public void UsePowerup(GameObject powerup, int playerNumber)
    {
        Destroy(powerup);
        StartCoroutine(WidthIncrease(playerNumber));
    }

    IEnumerator WidthIncrease(int pNumber)
    {
        FindObjectOfType<Soundmanager>().PlaySound("powerup");

        //get paddle components
        GameObject[] p = FindObjectOfType<Paddle>().GetPaddleReference();

        //enlarge paddle
        p[pNumber].transform.localScale = new Vector3(p[pNumber].transform.localScale.x, p[pNumber].transform.localScale.y + 2, p[pNumber].transform.localScale.z);
        yield return new WaitForSeconds(10);
        p[pNumber].transform.localScale = new Vector3(p[pNumber].transform.localScale.x, p[pNumber].transform.localScale.y - 2, p[pNumber].transform.localScale.z);
        yield return null;
    }

    private void Start()
    {
        StartCoroutine(SpawnPowerup());
    }

    IEnumerator SpawnPowerup()
    {
        yield return new WaitForSeconds(Random.Range(10f, 20f));
        Instantiate(powerup, new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f), 0), Quaternion.Euler(0, 0, 0), transform);
        StartCoroutine(SpawnPowerup());
        yield return null;
    }
}
