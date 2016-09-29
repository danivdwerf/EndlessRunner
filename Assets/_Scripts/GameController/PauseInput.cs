using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseInput : MonoBehaviour 
{
    private PauseLogic pauseLogic;
    private void Start()
    {
        pauseLogic = GetComponent<PauseLogic>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseLogic.GetInput();
        }
    }
}
