using UnityEngine;
using System;

public class LevelRespawn : MonoBehaviour
{
    RaycastHit hit;
    private Transform player;
    public event Action OnDeath = delegate { };

    private void Awake()
    {
        player = FindObjectOfType<PlayerEngine>().transform;
    }

    void Update()
    {
        if(Physics.Raycast(player.transform.position, -transform.up, out hit, 3))
        {
            if(hit.transform.tag == "Death")
            {
                OnDeath();
            }
        }
    }
}
