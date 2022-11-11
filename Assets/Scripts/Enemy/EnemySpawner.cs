using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnCooldownMin;
    [SerializeField] float spawnCooldownMax;

    [SerializeField] float spawnDistance;
    [SerializeField] GameObject[] enemies;

    void Start()
    {
        Invoke("SpawnEnemy", Random.Range(spawnCooldownMin, spawnCooldownMax));
    }

    public void SpawnEnemy()
    {
        int i = Random.Range(0, enemies.Length);
        Instantiate(enemies[i], GetSpawnPoint(), Quaternion.identity);

        Invoke("SpawnEnemy", Random.Range(spawnCooldownMin, spawnCooldownMax));
    }

    private Vector3 GetSpawnPoint()
    {
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 playerFaceDirection = GameObject.FindGameObjectWithTag("Player").transform.forward;

        float angleFromFaceDirection = Random.Range(-25.0f, 25.0f);
        Vector3 finalSpawnPoint = playerPos + Quaternion.Euler(0, angleFromFaceDirection, 0) * playerFaceDirection * spawnDistance;

        if (ARController.floorHeight != 0)
            finalSpawnPoint.y = ARController.floorHeight;
        else
            finalSpawnPoint.y = -0.5f;

        return finalSpawnPoint;
    }
}
