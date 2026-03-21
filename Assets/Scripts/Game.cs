using UnityEngine;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{
    // set in inspector
    public float enemySpawnDelay;
    public GameObject paperEnemyPrefab;
    public GameObject bookEnemyPrefab;
    public GameObject pythonEnemyPrefab;
    public BoxCollider2D spawnRange;

    // set in script
    private float enemySpawnTimer;

    void Awake() {
        // Initialize level data

        // Level 1
        enemySpawnData l1PaperSpawn = new enemySpawnData {prefab=paperEnemyPrefab, weight=1f}; //100%
        List<enemySpawnData> l1AllowedSpawns = new List<enemySpawnData> {l1PaperSpawn};
        Level level1 = new Level() {number=1, enemySpawnDelay=2.0f, allowedSpawns=l1AllowedSpawns};

        // Level 2
        enemySpawnData l2PaperSpawn = new enemySpawnData {prefab=paperEnemyPrefab, weight=3f}; //75%
        enemySpawnData l2BookSpawn = new enemySpawnData {prefab=bookEnemyPrefab, weight=4f}; //20%
        List<enemySpawnData> l2AllowedSpawns = new List<enemySpawnData> {l2PaperSpawn};
        Level level2 = new Level() {number=2, enemySpawnDelay=4.0f, allowedSpawns=l2AllowedSpawns};

        // Level 3
        enemySpawnData l3PaperSpawn = new enemySpawnData {prefab=paperEnemyPrefab, weight=4f}; //40%
        enemySpawnData l3BookSpawn = new enemySpawnData {prefab=bookEnemyPrefab, weight=8f}; //40%
        enemySpawnData l3PythonSpawn = new enemySpawnData {prefab=pythonEnemyPrefab, weight=10f}; //20%
        List<enemySpawnData> l3AllowedSpawns = new List<enemySpawnData> {l3PaperSpawn};
        Level level3 = new Level() {number=3, enemySpawnDelay=4.0f, allowedSpawns=l3AllowedSpawns};
    }

    void Update() {
        // check spawn enemy
        enemySpawnTimer += Time.deltaTime;
        if (enemySpawnTimer >= enemySpawnDelay) {
            SpawnEnemy();
            enemySpawnTimer = 0.0f;
        }
    }

    private void SpawnEnemy() {
        Vector3 enemySpawnPt = new Vector3(
            Random.Range(spawnRange.bounds.min.x, spawnRange.bounds.max.x),
            Random.Range(spawnRange.bounds.min.y, spawnRange.bounds.max.y),
            0);
        Instantiate(paperEnemyPrefab, enemySpawnPt, Quaternion.identity);
    }
}

public struct Level {
    public int number;
    public float enemySpawnDelay;
    public List<enemySpawnData> allowedSpawns;

    public Level(int levelNumber, float spawnDelay, List<enemySpawnData> spawns){
        this.number = levelNumber;
        this.enemySpawnDelay = spawnDelay;
        this.allowedSpawns = spawns;
    }
}

public struct enemySpawnData {
    public GameObject prefab;
    public float weight;

    public enemySpawnData(GameObject enemyPrefab, float enemyWeight){
        prefab = enemyPrefab;
        weight = enemyWeight;
    }
}