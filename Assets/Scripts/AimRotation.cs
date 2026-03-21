using UnityEngine;
using UnityEngine.InputSystem;

public class AimRotation : MonoBehaviour
{
    // set in inspector
    public GameObject mainCamera;

    // set in script
    private Camera cam;
    private Vector3 mousePos;

    void Start() {
        cam = mainCamera.GetComponent<Camera>();
    }

    void Update() {
        mousePos = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
	    Vector3 rotation = mousePos - transform.position;
	    float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
	    transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
