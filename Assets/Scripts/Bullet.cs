using UnityEngine;

public class Bullet : MonoBehaviour
{
    // set in inspector
    public float bulletSpeed = 90f;

    void Update()
    {
        this.transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);
    }
}
