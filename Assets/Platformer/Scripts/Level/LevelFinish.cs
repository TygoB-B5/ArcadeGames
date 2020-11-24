using UnityEngine;
using System;

public class LevelFinish : MonoBehaviour
{
    private Vector3 finish;
    private Transform player;
    public event Action OnFinishLevel = delegate { };

    private void Awake()
    {
        finish = GameObject.FindGameObjectWithTag("Finish").transform.position;
        player = FindObjectOfType<PlayerEngine>().transform;
    }

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, finish) < 2)
        {
            OnFinishLevel();
        }
    }
}
