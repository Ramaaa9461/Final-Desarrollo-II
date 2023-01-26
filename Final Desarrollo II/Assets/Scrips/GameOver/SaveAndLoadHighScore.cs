using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveAndLoadHighScore : MonoBehaviour
{

    string filePath = Application.dataPath + "/HighScore.txt";

    void CreateText()
    {
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "");
        }
    }

    private void Start()
    {
        CreateText();
    }

}
