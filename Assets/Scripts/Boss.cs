using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Boss : MonoBehaviour
{
    // set in inspector
    public float enemySpeed = 20f;
    public AudioClip spawn;
    public AudioClip death;
    public float bulletSpawnDelay = 0.5f;
    public GameObject bulletPrefab;
    public BoxCollider2D bulletSpawnRange;
    public float health;

    // set in script
    private AudioSource audioSrc;
    private IsEnemyType.EnemyType type;
    private float bulletSpawnTimer;

    void Start() {
        type = gameObject.GetComponent<IsEnemyType>().type;
        health = 100;

        audioSrc = GetComponent<AudioSource>();
        audioSrc.clip = spawn;
        audioSrc.Play();
    }

    void Update() {
        if (enemySpeed != 0){
            Vector3 leftVector = Vector3.left * enemySpeed * Time.deltaTime;
            if ((leftVector.magnitude + this.transform.position.x) > 5){
                this.transform.Translate(leftVector);
            } else {
                enemySpeed = 0;
            }
        } else {
            bulletSpawnTimer += Time.deltaTime;
            if (bulletSpawnTimer >= bulletSpawnDelay) {
                Vector3 bulletSpawnPt = new Vector3(
                    Random.Range(bulletSpawnRange.bounds.min.x, bulletSpawnRange.bounds.max.x),
                    Random.Range(bulletSpawnRange.bounds.min.y, bulletSpawnRange.bounds.max.y),
                    0);
                Instantiate(bulletPrefab, bulletSpawnPt, Quaternion.identity);
                bulletSpawnTimer = 0.0f; 
            }  
        } 
    }

    private void OnCollisionEnter2D(Collision2D c) {
        if (c.gameObject.CompareTag("Bullet")) {
            if (enemySpeed == 0){
                health -= 1;
                if (health == 0){
                    audioSrc.clip = death;
                    AudioSource.PlayClipAtPoint(death, this.transform.position, 1.0f);
                    Destroy(gameObject);
                    Score.Instance.HitEnemy(type);
                    UI.Instance.WinGame();
                } 
            }
        }
    }
}
