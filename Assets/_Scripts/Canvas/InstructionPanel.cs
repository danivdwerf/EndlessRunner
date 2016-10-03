using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InstructionPanel : MonoBehaviour 
{
    [SerializeField] private Button instructionButton;
    [SerializeField] private Button backButton; 
    [SerializeField] private GameObject instructionPanel;
    private void Start()
    {
        instructionPanel.SetActive(false);
    }

    private void Update()
    {
        instructionButton.onClick.AddListener(delegate(){OpenInstruction();}); 
        backButton.onClick.AddListener(delegate(){CloseInstruction();});
    }

    private void OpenInstruction()
    {
        instructionPanel.SetActive(true);
    }

    private void CloseInstruction()
    {
        instructionPanel.SetActive(false);
    }
}
