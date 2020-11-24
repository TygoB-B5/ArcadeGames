using UnityEngine;

public class LevelStart : MonoBehaviour
{
    private void Start()
    {
        RespawnPlayer();
        FindObjectOfType<LevelRespawn>().OnDeath += RespawnPlayer;
    }

    private void RespawnPlayer()
    {
        FindObjectOfType<PlayerEngine>().rb.velocity = new Vector3(0, 0, 0);
        FindObjectOfType<PlayerEngine>().transform.position = GameObject.FindGameObjectWithTag("Start").transform.position + new Vector3(0, 0.55f, 0);
        FindObjectOfType<PlayerEngine>().transform.rotation = Quaternion.Euler(0, GameObject.FindGameObjectWithTag("Start").transform.eulerAngles.y + 90, 0);
        FindObjectOfType<CameraFollow>().transform.position = FindObjectOfType<PlayerEngine>().transform.position - FindObjectOfType<CameraFollow>().offset;
    }
}
