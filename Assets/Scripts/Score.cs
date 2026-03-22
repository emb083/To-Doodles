using UnityEngine;

public class Score : MonoBehaviour
{
    private int score;

    public static Score Instance {get; private set;}

    private void Awake() {
        Instance = this;
        score = 0;
    }

    void Update() {
        if (score == 1500) {
            Game.Instance.UpdateLevel(2);
        }
        else if (score == 4500) {
            Game.Instance.UpdateLevel(3);
        }
        else if (score == 13000) {
            Game.Instance.UpdateLevel(4);
        }
    }

    public void HitEnemy(IsEnemyType.EnemyType type){
        score += (int)type;
    }
}
