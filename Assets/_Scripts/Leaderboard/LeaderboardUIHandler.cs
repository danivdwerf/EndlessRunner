using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LeaderboardUIHandler : MonoBehaviour
{
    [SerializeField]private GameObject inputPanel;
    [SerializeField]private GameObject leaderboardPanel;
    [SerializeField]private Text yourScore;
    private void Start()
    {
        inputPanel.SetActive(true);
        leaderboardPanel.SetActive(false);
        yourScore.text = "Your score was: " + PlayerPrefs.GetInt("curScore");
    }
    public void deleteInputUI()
    {
        inputPanel.gameObject.SetActive(false);
        leaderboardPanel.SetActive(true);
    }
}
