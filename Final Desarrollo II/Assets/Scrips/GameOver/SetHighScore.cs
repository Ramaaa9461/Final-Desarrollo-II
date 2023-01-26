using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreController : MonoBehaviour
{
    int[] highScores;
    int lastScore;

    private void Awake()
    {
        highScores = new int[3];
    }

    private void Start()
    {
        lastScore = PlayerPrefs.GetInt("EnemiesKilled");

        //tengo qe leer el archivo y llenar el array
    }



    public void setScore1(int score)
    {
        highScores[0] = score;
    }

    public void setScore2(int score)
    {
        highScores[1] = score;
    }

    public void setScore3(int score)
    {
        highScores[2] = score;
    }



    public int getScore1()
    {
        return highScores[0];
    }

    public int getScore2()
    {
        return highScores[1];
    }

    public int getScore3()
    {
        return highScores[2];
    }
}
