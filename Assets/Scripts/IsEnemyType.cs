using UnityEngine;

public class IsEnemyType : MonoBehaviour
{
    public enum EnemyType {
        Paper = 100,
        Book = 200,
        Python = 300,
        Boss = 10000
    }
    
    // set in inspector
    public EnemyType type;
}