using UnityEngine;
using System.Collections;

public class Die : MonoBehaviour 
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

    public void KillPlayer()
    {
        gameOver.StopGameScene();
        playerAudio.PlayAudio(hurt, false);
        playerMovement.Death = true;
        DeathAnimation.deathAnimation.Death();
    }
}
