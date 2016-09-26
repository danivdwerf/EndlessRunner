using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]private Text scoreText;
    [SerializeField]private Text highScoreText;

    private int score;
    private bool betterScore;
    private float highScore;
    public static Score score_script;

    private void Start()
    {
        score_script = this;
        highScore = PlayerPrefs.GetFloat("High Score");
        score = 0;
        betterScore = false;
        UpdateScoreUI();
    }

    private void Update()
    {
        UpdateScoreUI();
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("High Score", highScore);
        }
        if (score == highScore&&!betterScore)
        {
            Achievement.achievement.NewHighscore();
            betterScore = true;
        }
    }

    private void UpdateScoreUI()
    {
        score++;
        scoreText.text = "Score: "+ score;
        highScoreText.text = "Highscore: "+  highScore; 
    }
}