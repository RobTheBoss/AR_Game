using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnCooldown;
    [SerializeField] float spawnDistance;
    [SerializeField] GameObject enemy;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, spawnCooldown);
    }

    public void SpawnEnemy()
    {
        Instantiate(enemy, GetSpawnPoint(), Quaternion.identity);
    }

    private Vector3 GetSpawnPoint()
    {
        Vector3 spawnDirection = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f)).normalized;

        Vector3 finalSpawnPoint = new Vector3(0,0,0) + (spawnDirection * spawnDistance);
        finalSpawnPoint.y = ARController.floorHeight;
        Debug.Log("Enemy Spawn Found");
        return finalSpawnPoint;
    }
}
