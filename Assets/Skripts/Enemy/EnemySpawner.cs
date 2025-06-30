using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // References
    public GameObject enemyPreFab;
    public GameObject bigAssEnemyPrefab;

    //public Transform spawnPoint;
    [SerializeField] float radius = 15f;

    

    void Awake()
    {

    }

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, 1f / GameManager.Instance.enemySpawnRate);
        InvokeRepeating("SpawnBigAssEnemy", 0f, 1f / GameManager.Instance.bigAssEnemySpawnRate);
    }

    void SpawnEnemy()
    {
        Vector2 spawnPos = GetRandomSpawnPosition();
        Instantiate(enemyPreFab, spawnPos, Quaternion.identity);
    }
    void SpawnBigAssEnemy()
    {
        Vector2 spawnPos = GetRandomSpawnPosition();
        Instantiate(bigAssEnemyPrefab, spawnPos, Quaternion.identity);
    }

    Vector2 GetRandomSpawnPosition()
    {
        // Mittelpunkt der Szene
        Vector2 center = Vector2.zero;

        // Radius für den Ring
        // float radius = 15f;

        //zufälliger Winkel in Radiant
        float angle = UnityEngine.Random.Range(0f, 2f * Mathf.PI);

        // Koordinaten berechnen
        float x = center.x + radius * Mathf.Cos(angle);
        float y = center.y + radius * Mathf.Sin(angle);

        return new Vector2(x, y);  

    }
}