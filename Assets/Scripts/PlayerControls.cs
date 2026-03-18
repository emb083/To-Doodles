using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerActions inputActions;
    public float movementSpeed = 6f;
    private const float LEFT_LIMIT = -8.4f;
    private const float RIGHT_LIMIT = 0f;
    private const float Y_LIMIT = 4.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputActions = new ();
        inputActions.Enable();
        inputActions.Standard.Enable();
    }

    // Update is called once per frame
    void Update()
    {
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

        // bounds (double-checking)

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
}
