using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayOptions : MonoBehaviour
{
    [SerializeField] GameObject InstructionsPanel;
    [SerializeField] TextMeshProUGUI InstructionsText;
    [SerializeField] TextAsset InstructionsTextAsset;

    [SerializeField] GameObject PausePanel;
    [SerializeField] Button pauseButton;

    void Start()
    {
        InstructionsText.text = InstructionsTextAsset.text;

        Time.timeScale = 0;
    }

    void Update()
    {

        if (InstructionsPanel.activeSelf)
        {
            if (Input.anyKeyDown)
            {
                InstructionsPanel.SetActive(false);
                Time.timeScale = 1;
            }
        }

        if (PausePanel.activeSelf == false)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                pauseButton.onClick.Invoke();
            }
        }

    }
}
