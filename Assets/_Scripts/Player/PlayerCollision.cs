using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour 
{
    private Die die;
    private ScreenShake screenShake;
    private void Start()
    {
        die = GetComponent<Die>();
        screenShake = GetComponentInChildren<ScreenShake>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(Tags.wall))
        {
            die.KillPlayer();
            screenShake.StartShaking = true;
        }
    }
}
