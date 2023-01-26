using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHighScore : MonoBehaviour
{
    int lastScore;
    SaveAndLoadHighScore saveAndLoadHighScore;
    HighScoreTable highScoreTable;
    HighScoreUIController highScoreUIController;

    private void Awake()
    {
        saveAndLoadHighScore = gameObject.GetComponent<SaveAndLoadHighScore>();
        highScoreUIController = gameObject.GetComponent<HighScoreUIController>();
    }

    private void Start()
    {
        lastScore = PlayerPrefs.GetInt("EnemiesKilled");
        highScoreTable = saveAndLoadHighScore.getHighScoreTable();

        int[] array = new int[] { highScoreTable.score1, highScoreTable.score2, highScoreTable.score3, lastScore };

        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array.Length - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    int aux = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = aux;
                }
            }
        }

        highScoreTable.score1 = array[0];
        highScoreTable.score2 = array[1];
        highScoreTable.score3 = array[2];

        saveAndLoadHighScore.setHighScoreTable(highScoreTable);
        highScoreUIController.RecibeHighScoreValues(highScoreTable);
    }
}
