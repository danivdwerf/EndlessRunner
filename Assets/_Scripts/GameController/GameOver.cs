using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour 
{
    public void StopGameScene()
    {
        StartCoroutine(StopGame());
    }

    IEnumerator StopGame()
    {
        Score.score_script.enabled = false;
        PlayerMovement.playerMovement.enabled = false;
        PlayerInput.playerInput.enabled = false;
        TrackBuilder.trackBuilder.enabled = false;
        yield return new WaitForSeconds(3f);
        SceneSwitcher.scene_switcher.RetryScene();
    }
}
