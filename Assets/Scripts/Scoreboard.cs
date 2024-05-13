using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    
    int score;
    TMP_Text scoreText;

    void Start() 
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Start";
    }

    public void ScoreHit(int scoreIncrease)
    {
        score += scoreIncrease;
        scoreText.text = score.ToString();
    }
}
