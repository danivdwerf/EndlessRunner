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
    public void GameScene()
    {
        SceneManager.LoadScene(0);
    }

    public void RetryScene()
    {
        SceneManager.LoadScene(1);
    }
}