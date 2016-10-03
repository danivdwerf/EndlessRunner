using UnityEngine;
using System.Collections;

public class PauseInput : MonoBehaviour 
{
    private PauseLogic pauseLogic;
    private PlayerMovement playerMovement;
    private void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        pauseLogic = GetComponent<PauseLogic>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&!playerMovement.Death)
        {
            pauseLogic.GetInput();
        }
    } 
}
