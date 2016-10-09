using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour 
{
    private float shakeTime, intensity;
    private bool shaking;

    private void Start()
    {
        shakeTime = 1f;
        intensity = 0.1f;
        shaking = false;
    }

    public bool StartShaking
    {
        set{shaking = value;}
    }

    private void Update()
    {
        if (shaking)
        {
            if (shakeTime > 0)
            {
                shakeTime -= Time.deltaTime;
                Shake();    
            }
        }
    }

    private void Shake()
    {
        transform.localPosition= Random.insideUnitCircle*intensity;
    }
}
