using UnityEngine;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    // set in inspector
    public float enemySpeed = 0.1f;
    public GameObject bugPrefab = null;
    public List<Transform> bugSpawns = null;

    void Update() {
        this.transform.Translate(Vector3.left * enemySpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D c) {
        if (c.CompareTag("Bounds")) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D c) {
        if (c.gameObject.CompareTag("Bullet")) {
            IsEnemyType.EnemyType type = gameObject.GetComponent<IsEnemyType>().type;

            if (type == IsEnemyType.EnemyType.Python) {
                foreach (Transform bugSpawnpoint in bugSpawns) {
                    Instantiate(bugPrefab, bugSpawnpoint.position, bugSpawnpoint.rotation);
                }
            }

            Destroy(gameObject);
            Score.Instance.HitEnemy(type);
        }
    }
}
