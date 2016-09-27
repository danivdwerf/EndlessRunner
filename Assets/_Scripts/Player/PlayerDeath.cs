using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour 
{
    [SerializeField]private AudioClip hurt;
    private PlayerAudio playerAudio;
    private GameOver gameOver;

    private void Start()
    {
        playerAudio = GameObject.FindObjectOfType<PlayerAudio>();
        gameOver = GameObject.FindObjectOfType<GameOver>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(Tags.wall))
        {
            gameOver.StopGameScene();
            playerAudio.PlayAudio(hurt, false);
            DeathAnimation.deathAnimation.Death();
        }
    }
}
