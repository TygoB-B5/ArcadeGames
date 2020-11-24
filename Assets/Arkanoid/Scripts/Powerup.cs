using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private bool isActivated = false;

    void Update()
    {
        if (!isActivated)
            return;

        transform.position -= new Vector3(0, 4, 0) * Time.deltaTime;
    }
    public void SpawnPowerup()
    {
        isActivated = true;
        transform.parent = null;
        Destroy(gameObject, 10);
        Debug.Log("Powerup Spawned");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<SoundHandler>().PlaySound("powerup");
            Debug.Log("Picked up powerup");
            Destroy(gameObject, 0);
            FindObjectOfType<Paddlecontroller>().EnablePowerupMethod();
        }
    }
}
