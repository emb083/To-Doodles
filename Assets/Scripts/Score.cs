using UnityEngine;

public class Score : MonoBehaviour
{
    public int score;

    public static Score Instance {get; private set;}

    private void Awake() {
        Instance = this;
        score = 0;
    }

    void Update() {
        if (score >= 4000 && score < 12500) {
            Game.Instance.UpdateLevel(2);
        }
        else if (score >= 12500 && score < 25000) {
            Game.Instance.UpdateLevel(3);
        }
        else if (score >= 25000) {
            Game.Instance.UpdateLevel(4);
        }
    }

    public void HitEnemy(IsEnemyType.EnemyType type){
        score += (int)type;
    }
}
