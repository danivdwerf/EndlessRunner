using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InstructionPanel : MonoBehaviour 
{
    [SerializeField] private Button instructionButton;
    [SerializeField] private Button backButton; 
    [SerializeField] private GameObject start;
    [SerializeField] private GameObject exit;
    [SerializeField] private GameObject instructionPanel;
    private void Start()
    {
        instructionPanel.SetActive(false);
        start.SetActive(true);
        exit.SetActive(true);
        instructionButton.gameObject.SetActive(true);
    }

    private void Update()
    {
        instructionButton.onClick.AddListener(delegate(){OpenInstruction();}); 
        backButton.onClick.AddListener(delegate(){CloseInstruction();});
    }

    private void OpenInstruction()
    {
        instructionPanel.SetActive(true);
        start.SetActive(false);
        exit.SetActive(false);
        instructionButton.gameObject.SetActive(false);
    }

    private void CloseInstruction()
    {
        instructionPanel.SetActive(false);
        start.SetActive(true);
        exit.SetActive(true);
        instructionButton.gameObject.SetActive(true);
    }
}
