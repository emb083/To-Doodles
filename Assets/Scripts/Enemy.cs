using UnityEngine;

public class Enemy : MonoBehaviour
{
    // set in inspector
    public float enemySpeed = 0.1f;

    void Start() {
        
    }

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
            Destroy(gameObject);
            Score.Instance.HitEnemy(gameObject.GetComponent<IsEnemyType>().type);
        }
    }
}
