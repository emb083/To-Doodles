using TMPro;
using UnityEngine;

public class TextUpdater : MonoBehaviour
{
    public Game game;
    public Score score;
    public PlayerMovement playerMovement;

    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI levelTxt;
    public TextMeshProUGUI healthTxt;


    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = "SCORE: " + score.score.ToString();
        levelTxt.text = "LEVEL: " + game.level.ToString();
        healthTxt.text = "GPA: " + playerMovement.gpa.ToString();
    }
}
