using UnityEngine;

public class Bug : MonoBehaviour
{
    // set in inspector
    public float bulletSpeed = 15f;

    void Update() {
        this.transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Bounds")) {
            Destroy(gameObject);
        }
    }
}
