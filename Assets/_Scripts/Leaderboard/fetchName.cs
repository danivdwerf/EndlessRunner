using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fetchName : MonoBehaviour  
{
    private string username;
    private LeaderboardUIHandler uiHandler;
    private sqlconnect sql;
    [SerializeField]private InputField inputField;
    [SerializeField]private Button confirm;
    private void Start()
    {
        uiHandler = GetComponent<LeaderboardUIHandler>();
        sql = GetComponent<sqlconnect>(); 
        confirm.onClick.AddListener(delegate(){GetInput();});
    }
    private void GetInput()
    {
        username=inputField.text;
        uiHandler.deleteInputUI();
        sql.LoadLeaderBoard(username);
    }
    public string GetName
    {
        get
        { 
            return username;
        }
    }
}
