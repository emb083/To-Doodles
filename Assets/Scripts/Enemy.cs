using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    // set in inspector
    public float enemySpeed = 0.1f;
    public GameObject bugPrefab = null;
    public List<Transform> bugSpawns = null;
    public bool followsPlayer;
    public AudioClip spawn;
    public AudioClip death;
    public AudioClip bugs = null;
    public AudioClip gremlin = null;

    // set in script
    private AudioSource audioSrc;
    private IsEnemyType.EnemyType type;

    void Start() {
        type = gameObject.GetComponent<IsEnemyType>().type;

        audioSrc = GetComponent<AudioSource>();
        audioSrc.clip = spawn;
        audioSrc.Play();

        if (type == IsEnemyType.EnemyType.Book){
            StartCoroutine(Wait(audioSrc.clip.length));
            audioSrc.clip = gremlin;
            audioSrc.loop = true;
            audioSrc.Play();
        }
        
    }

    void Update() {
        if (followsPlayer){
            Vector3 playerPos = GetPlayerPosition.Instance.GetPos();
            this.transform.position = Vector3.MoveTowards(transform.position, playerPos, (enemySpeed * Time.deltaTime));
        } else {
            this.transform.Translate(Vector3.left * enemySpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D c) {
        if (c.CompareTag("Bounds")) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D c) {
        if (c.gameObject.CompareTag("Bullet")) {
            if (type == IsEnemyType.EnemyType.Python) {
                foreach (Transform bugSpawnpoint in bugSpawns) {
                    Instantiate(bugPrefab, bugSpawnpoint.position, bugSpawnpoint.rotation);
                    audioSrc.clip = bugs;
                    AudioSource.PlayClipAtPoint(audioSrc.clip, this.transform.position);
                }
            }

            audioSrc.loop = false;
            audioSrc.clip = death;
            AudioSource.PlayClipAtPoint(audioSrc.clip, this.transform.position);
            Destroy(gameObject);
            Score.Instance.HitEnemy(type);
        }
    }

    private IEnumerator Wait(float s) {
        yield return new WaitForSeconds(s);
    }
}
