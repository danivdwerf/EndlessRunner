using UnityEngine;
using System.Collections;

public class CheckPlayerHeight : MonoBehaviour 
{
    private Die die;
    private PlayerMovement playerMovement;
    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        die = GetComponent<Die>();
    }

    private void Update()
    {
        if (transform.position.y <= -1&&!playerMovement.Death)
        {
            die.KillPlayer();
        }
    }
}
