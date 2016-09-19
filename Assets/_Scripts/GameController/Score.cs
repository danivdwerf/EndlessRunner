using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]private Text scoreText;
    [SerializeField]private Text highScoreText;
    [SerializeField]private string uppertText;
    [SerializeField]private string lowerText;
    public static Score score_script;

    private int score;
    private bool better_score;
    private float highScore;

    void Start()
    {
        score_script = this;
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
        scoreText.text = uppertText +' '+ score;
        highScoreText.text = lowerText +' '+  highScore;
    }
}