using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreUIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score1;
    [SerializeField] TextMeshProUGUI score2;
    [SerializeField] TextMeshProUGUI score3;

    public void RecibeHighScoreValues(HighScoreTable highScore)
    {
        score1.text = "" + highScore.score1.ToString();
        score2.text = "" + highScore.score2.ToString();
        score3.text = "" + highScore.score3.ToString();
    }
}
