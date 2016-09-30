using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QualityUI : MonoBehaviour
{
    [SerializeField] private Text qualityText;
    public void qualityName(int i)
    {
        qualityText.text = "Quality: " + QualitySettings.names[i];
    }
}
