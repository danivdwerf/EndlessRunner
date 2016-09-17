using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour 
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            StartCoroutine(StopGame());
        }
    }

    IEnumerator StopGame()
    {
        PlayerMovement.player_movement.Hurt();
        Score.score_script.enabled = false;
        PlayerMovement.player_movement.enabled = false;
        TrackBuilder.track_builder.enabled = false;
        yield return new WaitForSeconds(1f);
        SceneSwitcher.scene_switcher.Retry_Scene();
    }
}
