using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour 
{
    [SerializeField]private AudioClip hurt;
    private PlayerAudio playerAudio;
    private GameOver gameOver;
    private PlayerMovement playerMovement;

    private void Start()
    {
        playerAudio = GameObject.FindObjectOfType<PlayerAudio>();
        gameOver = GameObject.FindObjectOfType<GameOver>();
        playerMovement = GetComponent<PlayerMovement>();
        playerMovement.Death = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(Tags.wall))
        {
            gameOver.StopGameScene();
            playerAudio.PlayAudio(hurt, false);
            playerMovement.Death = true;
            DeathAnimation.deathAnimation.Death();
        }
    }
}
