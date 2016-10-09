using UnityEngine;
using System.Collections;

public class PauseLogic : MonoBehaviour 
{
    [SerializeField] private GameObject pausePanel;
    private PlayerAudio playerAudio;
    private bool paused;
    void Start()
    {
        pausePanel.SetActive(false);
        paused = false;
        playerAudio = GetComponent<PlayerAudio>();
        Time.timeScale = 1;
    }

    public void GetInput()
    {
        switch (paused)
        {
            case true: ContinueGame();
            break;
            case false: PauseGame();
            break;
            default: return;
            break;
        }
    }

    private void PauseGame()
    {
        if (!paused)
        {
            Time.timeScale = 0;
            paused = true;
            Score.score_script.enabled = false;
            PlayerInput.playerInput.enabled = false;
            playerAudio.PlayAudio(null, false);
            pausePanel.SetActive(true);
        }
    }

    public void ContinueGame()
    {
        if (paused)
        {
            Time.timeScale = 1;
            paused = false;
            Score.score_script.enabled = true;
            PlayerInput.playerInput.enabled = true;
            pausePanel.SetActive(false);
        }
    }
}
