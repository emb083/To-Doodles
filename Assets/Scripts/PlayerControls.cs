using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // set in inspector
    public float movementSpeed = 6f;
    public GameObject bulletPrefab;
    public Transform bulletSpawnpoint;
    public AudioClip shoot;
    public AudioClip hurt;

    // set in code
    private PlayerActions inputActions;
    private const float LEFT_LIMIT = -8.4f;
    private const float RIGHT_LIMIT = 0f;
    private const float Y_LIMIT = 4.5f;
    private AudioSource audioSrc;
    private float gpa;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        inputActions = new ();
        inputActions.Enable();
        inputActions.Standard.Enable();

        audioSrc = GetComponent<AudioSource>();

        gpa = 4.0f;
        print($"GPA: {gpa}");
    }

    // Update is called once per frame
    void Update() {
        PlayerActions.StandardActions input = inputActions.Standard;
        float x_pos = this.transform.position.x;
        float y_pos = this.transform.position.y;

        // controls

        if (input.MoveUp.IsPressed()){
            Vector3 upVector = Vector3.up * movementSpeed * Time.deltaTime;
            if ((upVector.magnitude + y_pos) < Y_LIMIT){
               this.transform.Translate(upVector); 
            }
        }

        if (input.MoveDown.IsPressed()){
            Vector3 downVector = Vector3.down * movementSpeed * Time.deltaTime;
            if ((downVector.magnitude + y_pos) > -Y_LIMIT){
                this.transform.Translate(downVector);
            }
        }

        if (input.MoveLeft.IsPressed()){
            Vector3 leftVector = Vector3.left * movementSpeed * Time.deltaTime;
            if ((leftVector.magnitude + x_pos) > LEFT_LIMIT){
                this.transform.Translate(leftVector);  
            }
        }

        if (input.MoveRight.IsPressed()){
            Vector3 rightVector = Vector3.right * movementSpeed * Time.deltaTime;
            if ((rightVector.magnitude + x_pos) < RIGHT_LIMIT){
                this.transform.Translate(rightVector);  
            }
        }

        if (input.Shoot.WasPressedThisFrame()) {
            Instantiate(bulletPrefab, bulletSpawnpoint.position, bulletSpawnpoint.rotation);
            audioSrc.clip = shoot;
            audioSrc.Play();
        }

        // movement bounds (double-checking)

        if (y_pos > Y_LIMIT){
            this.transform.position = new Vector3(x_pos, Y_LIMIT);
        }

        else if (y_pos < -Y_LIMIT){
            this.transform.position = new Vector3(x_pos, -Y_LIMIT);
        }

        else if (x_pos > RIGHT_LIMIT){
            this.transform.position = new Vector3(RIGHT_LIMIT, y_pos);
        }

        else if (x_pos < LEFT_LIMIT){
            this.transform.position = new Vector3(LEFT_LIMIT, y_pos);
        }
    }

    private void OnCollisionEnter2D(Collision2D c) {
        if (c.gameObject.CompareTag("Enemy")) {
            audioSrc.clip = hurt;
            audioSrc.Play();

            switch (c.gameObject.GetComponent<IsEnemyType>().type) {
                case IsEnemyType.EnemyType.Book:
                    gpa -= 1f;
                    break;
                case IsEnemyType.EnemyType.Python:
                    gpa -= 2f;
                    break;
                default: // defaults to paper
                    gpa -= 0.5f;
                    break;
            }
            print($"GPA: {gpa}");

            if (gpa <= 0f){
                Destroy(gameObject);
            }
        }
    }
}
