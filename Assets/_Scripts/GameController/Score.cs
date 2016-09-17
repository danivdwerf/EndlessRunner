using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]private Text scoreText;
    [SerializeField]private Text highScoreText;
    public static Score score_script;

    private int score;
    private bool better_score;
    private float highScore;

    void Start()
    {
        score_script = this;
        PlayerPrefs.SetFloat("High Score", 0);
        highScore = PlayerPrefs.GetFloat("High Score");
        score = 0;
        better_score = false;
        UpdateScoreUI();
    }

    void Update()
    {
        UpdateScoreUI();
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("High Score", highScore);
        }
        if (score == highScore&&!better_score)
        {
            Achievement.achievement.NewHighscore();
            better_score = true;
        }
    }

    void UpdateScoreUI()
    {
        score++;
        scoreText.text = "Score: " + score;
        highScoreText.text = "HighScore: " + highScore;
    }
}