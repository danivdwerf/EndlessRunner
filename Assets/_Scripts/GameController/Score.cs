using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]private Text scoreText;
    [SerializeField]private Text highScoreText;
    public static Score score_script;

    private int score;
    private float highScore;

    void Start()
    {
        score_script = this;
        highScore = PlayerPrefs.GetFloat("High Score");
        score = 0;
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
    }

    void UpdateScoreUI()
    {
        score++;
        scoreText.text = "Score: " + score;
        highScoreText.text = "HighScore: " + highScore;
    }
}