using UnityEngine;

public class BossBullet : MonoBehaviour
{
    // set in inspector
    public float bulletSpeed = 15f;

    void Update() {
        this.transform.Translate(Vector3.left * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Bounds")) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D c) {
        if (c.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
        }
    }
}
