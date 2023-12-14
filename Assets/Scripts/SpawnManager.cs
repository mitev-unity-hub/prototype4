using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPosition = new Vector3(25, 0 , 0);
    private float startDelay = 2.0f;
    private float repeatSpawnRate = 2.0f;

    void Start()
    {
        InvokeRepeating("spawnObstacles", startDelay, repeatSpawnRate);
    }

    void spawnObstacles()
    {
        Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
    }
}
