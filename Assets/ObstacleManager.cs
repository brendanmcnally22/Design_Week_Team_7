using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject Obstacle; // 
    public float spawnInterval = 3f; // Time between spawns
    private float spawnTimer;

    public float spawnRangeX = 8f; // Adjust based on screen size
    public float spawnRangeY = 4f; // Adjust based on screen size

    void Start()
    {
        spawnTimer = spawnInterval;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnObstacle();
            spawnTimer = spawnInterval; // Reset the timer
        }
    }

    void SpawnObstacle()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        float randomY = Random.Range(-spawnRangeY, spawnRangeY);
        Vector2 spawnPosition = new Vector2(randomX, randomY);

        Instantiate(Obstacle, spawnPosition, Quaternion.identity);
    }
}

