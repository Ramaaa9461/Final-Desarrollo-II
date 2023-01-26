using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class SaveAndLoadHighScore : MonoBehaviour
{

    string filePath;
    HighScoreTable table;


    private void Awake()
    {
        filePath = Application.persistentDataPath + "/HighScore.dat";
        table = new HighScoreTable();
    }

    private void Start()
    {
        table.score1 = 10;
        table.score2 = 1;
        table.score3 = 8;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            WriteHighScore(table);
        }
    }


    public HighScoreTable readHighScore()
    {
        string[] text = File.ReadAllLines(filePath);

        return table;
    }

    public void WriteHighScore(HighScoreTable highScore)
    {
        FileStream file = new FileStream(filePath, FileMode.OpenOrCreate);

        BinaryFormatter formatter = new BinaryFormatter();

        formatter.Serialize(file, highScore);

        file.Close();
    }
}
