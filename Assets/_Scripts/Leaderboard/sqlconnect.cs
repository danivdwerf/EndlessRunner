using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class sqlconnect : MonoBehaviour
{
    private string secretKey = "Mustard";
    public string addScoreURL = "http://freetimedev.com/Highscores/setScore.php?"; //ADD A ? TO THE LINK DANI!!!!!!
    public string highscoreURL = "http://freetimedev.com/Highscores/getScore.php"; //DON'T ADD THE FUCKING ? TO THIS LINK DANI
    private md5 md5script;
    [SerializeField] private Text loadingText;

    void Start()
    {
        md5script = GetComponent<md5>();
    }
    public void LoadLeaderBoard(string playerName)
    {
        StartCoroutine(PostScores(playerName,PlayerPrefs.GetInt("curScore")));
        StartCoroutine(GetScores());
    }

    IEnumerator PostScores(string name, int score)
    {
        string hash = md5script.Md5Sum(name + score + secretKey);
        string post_url = addScoreURL + "name=" + WWW.EscapeURL(name) + "&score=" + score + "&hash=" + hash;
        WWW hs_post = new WWW(post_url);
        yield return hs_post;

        if (hs_post.error != null)
        {
            print("There was an error posting the high score: " + hs_post.error);
        }
    }
    IEnumerator GetScores()
    {
        loadingText.text = "Loading Scores...";
        yield return new WaitForSeconds(0.5f);
        WWW hs_get = new WWW(highscoreURL);
        yield return hs_get;

        if (hs_get.error != null)
        {
            print("There was an error getting the high score: " + hs_get.error);
        }
        else
        {
            loadingText.text = hs_get.text;
        }
    }

}