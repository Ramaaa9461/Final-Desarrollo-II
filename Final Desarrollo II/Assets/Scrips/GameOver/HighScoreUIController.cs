using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreUIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score1;
    [SerializeField] TextMeshProUGUI score2;
    [SerializeField] TextMeshProUGUI score3;

    private void Start()
    {
        //Cargar son el save and load
    }

    public void setScore1(int score)
    {
        score1.text = score.ToString(); 
    }
    public void setScore2(int score)
    {
        score2.text = score.ToString();
    }
    public void setScore3(int score)
    {
        score3.text = score.ToString();
    }
}
