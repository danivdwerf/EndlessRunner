using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]private Text scoreText;
    [SerializeField]private Text highScoreText;
    [SerializeField] private AudioClip oh_wow;
    private AudioSource source;
    public static Score score_script;

    private int score;
    private bool better_score;
    private float highScore;

    void Start()
    {
        score_script = this;
        highScore = PlayerPrefs.GetFloat("High Score");
        source = GetComponent<AudioSource>();
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
            PlayAudio();
        }
    }

    void UpdateScoreUI()
    {
        score++;
        scoreText.text = "Score: " + score;
        highScoreText.text = "HighScore: " + highScore;
    }

    private void PlayAudio()
    {
        better_score = true;
        source.PlayOneShot(oh_wow);
    }
}