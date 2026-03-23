using UnityEngine;

public class GetPlayerPosition : MonoBehaviour
{
    public static GetPlayerPosition Instance {get; private set;}

    private void Awake() {
        Instance = this;
    }

    public Vector3 GetPos(){
        return this.transform.position;
    }
}
