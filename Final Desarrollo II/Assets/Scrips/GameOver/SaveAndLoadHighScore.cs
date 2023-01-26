using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class SaveAndLoadHighScore : MonoBehaviour
{

    string filePath;
    HighScoreTable highScoreTable;


    private void Awake()
    {
        filePath = Application.persistentDataPath + "/HighScore.dat";
        highScoreTable = new HighScoreTable();
    }

    private void Start()
    {
        if (File.Exists(filePath))
        {
            highScoreTable = ReadHighScore();
        }
        else
        {
            highScoreTable.score1 = 0;
            highScoreTable.score2 = 0;
            highScoreTable.score3 = 0;

            WriteHighScore();
        }
    }

    public HighScoreTable ReadHighScore()
    {
        FileStream file = new FileStream(filePath, FileMode.Open);
        
        BinaryFormatter formatter = new BinaryFormatter();
        
        highScoreTable = (HighScoreTable)formatter.Deserialize(file);

        file.Close();

        return highScoreTable;
    }

    public void WriteHighScore()
    {
        FileStream file = new FileStream(filePath, FileMode.OpenOrCreate);

        BinaryFormatter formatter = new BinaryFormatter();

        formatter.Serialize(file, highScoreTable);

        file.Close();
    }

    public HighScoreTable getHighScoreTable()
    {
        return highScoreTable;
    }
    public void setHighScoreTable(HighScoreTable HSTable)
    {
        highScoreTable = HSTable;
        WriteHighScore();
    }
}
