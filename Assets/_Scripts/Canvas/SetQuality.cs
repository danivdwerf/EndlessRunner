using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetQuality : MonoBehaviour
{
    [SerializeField] private Button lowButton;
    [SerializeField] private Button mediumButton;
    [SerializeField] private Button highButton;

    private QualityUI qualityUI;

    private void Start()
    {
        qualityUI = GetComponent<QualityUI>();
        if (PlayerPrefs.GetInt("quality") == null)
        {
            PlayerPrefs.SetInt("quality", 1);
        }
        else
        {
            ChangeQuality(PlayerPrefs.GetInt("quality"));
        }
    }

    private void ChangeQuality(int i)
    {
        QualitySettings.SetQualityLevel(i);
        qualityUI.qualityName(i);
        PlayerPrefs.SetInt("quality", i);
    }

    private void Update()
    {
        lowButton.onClick.AddListener(delegate(){ChangeQuality(0);});
        mediumButton.onClick.AddListener(delegate(){ChangeQuality(1);});
        highButton.onClick.AddListener(delegate(){ChangeQuality(2);});
    }
        
}
