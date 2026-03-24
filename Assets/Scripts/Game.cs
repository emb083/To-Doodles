using UnityEngine;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{
    public static Game Instance {get; private set;}

    // set in inspector
    public GameObject paperEnemyPrefab;
    public GameObject bookEnemyPrefab;
    public GameObject pythonEnemyPrefab;
    public GameObject bossPrefab;
    public BoxCollider2D spawnRange;
    public float enemySpawnDelay;
    public int level = 1;

    // set in script
    private float enemySpawnTimer;

    private void Awake() {
        Instance = this;
        UpdateLevel(1);
    }

    void Update() {
        // check spawn enemy
        enemySpawnTimer += Time.deltaTime;
        if (enemySpawnTimer >= enemySpawnDelay && enemySpawnDelay != 0f) {
            GameObject enemy = ChooseEnemy();
            if (enemy != bossPrefab){
               SpawnEnemy(enemy);
               enemySpawnTimer = 0.0f; 
            } else {
                SpawnBoss();
                enemySpawnDelay = 0f;
            }
            
        }
    }

    private GameObject ChooseEnemy() {
        float randChoice = Random.value;
        GameObject chosenEnemy;
        
        switch (level) {
            case 2:
                if (randChoice <= 0.6) {
                    chosenEnemy = paperEnemyPrefab; // 60% chance
                } else {
                    chosenEnemy = bookEnemyPrefab; // 40% chance
                }
                break;
            case 3:
                if (randChoice <= 0.4) {
                    chosenEnemy = paperEnemyPrefab; // 40% chance
                } else if (randChoice <= 0.75) {
                    chosenEnemy = bookEnemyPrefab; // 35% chance
                } else {
                    chosenEnemy = pythonEnemyPrefab; // 25% chance
                }
                break;
            case 4:
                chosenEnemy = bossPrefab;
                break;
            default: // default to level 1 behavior
                chosenEnemy = paperEnemyPrefab; // 100% chance
                break;
        }

        return chosenEnemy;
    }

    private void SpawnEnemy(GameObject enemyPrefab) {
        Vector3 enemySpawnPt = new Vector3(
            Random.Range(spawnRange.bounds.min.x, spawnRange.bounds.max.x),
            Random.Range(spawnRange.bounds.min.y, spawnRange.bounds.max.y),
            0);
        Instantiate(enemyPrefab, enemySpawnPt, Quaternion.identity);
    }

    private void SpawnBoss() {
        Vector3 bossSpawnPt = new Vector3(12.5f, -0.5f, 0);
        Instantiate(bossPrefab, bossSpawnPt, Quaternion.identity);
    }

    public void UpdateLevel(int newLevel) {
        switch (newLevel) {
            case 2:
                level = 2;
                enemySpawnDelay = 0.75f;
                break;
            case 3:
                level = 3;
                enemySpawnDelay = 0.5f;
                break;
            case 4:
                level = 4;
                // override spawn delay after boss spawns
                break;
            default: // default to level 1
                level = 1;
                enemySpawnDelay = 1.0f;
                break;
        }
    }
}

