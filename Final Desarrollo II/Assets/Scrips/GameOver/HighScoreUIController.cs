using TMPro;
using UnityEngine;


namespace Game
{

    public class HighScoreUIController : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI score1;
        [SerializeField] TextMeshProUGUI score2;
        [SerializeField] TextMeshProUGUI score3;
        [SerializeField] TextMeshProUGUI lastScore;

        public void RecibeHighScoreValues(HighScoreTable highScore, int _lastScore)
        {
            score1.text = "" + highScore.score1.ToString();
            score2.text = "" + highScore.score2.ToString();
            score3.text = "" + highScore.score3.ToString();
            lastScore.text = "" + _lastScore.ToString();

        }
    }
}