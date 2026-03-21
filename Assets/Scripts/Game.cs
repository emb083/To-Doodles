using UnityEngine;

public class Game : MonoBehaviour
{
    // set in inspector
    public float enemySpawnDelay;
    public GameObject enemyPrefab;
    public BoxCollider2D spawnRange;

    // set in script
    private float enemySpawnTimer;

    void Start() {
        
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
        Instantiate(enemyPrefab, enemySpawnPt, Quaternion.identity);
    }
}
