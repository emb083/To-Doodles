using UnityEngine;

public class IsEnemyType : MonoBehaviour
{
    public enum EnemyType {
        Paper = 100,
        Book = 200,
        Python = 300
    }
    
    // set in inspector
    public EnemyType type;
}