using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour 
{
    private PlayerMovement playerMovement;
    public static PlayerInput playerInput;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerInput = this;
    }

    private void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerMovement.Jump();
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerMovement.SideWays(-10000);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerMovement.SideWays(10000);
        }
        else
        {
            playerMovement.SideWays(0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerMovement.Slide();
        }
        else
        {
            playerMovement.Run();
        }
    }
}
