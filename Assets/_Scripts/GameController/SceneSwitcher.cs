using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour 
{
    public static SceneSwitcher scene_switcher;
    private void Start()
    {
        scene_switcher = this;
    }
    public void Game_Scene()
    {
        SceneManager.LoadScene(0);
    }

    public void Retry_Scene()
    {
        SceneManager.LoadScene(1);
    }
}