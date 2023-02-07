using TMPro;
using UnityEngine;


namespace Game
{
    public class CreditsParser : MonoBehaviour
    {

        [SerializeField] TextAsset creditsTextAsset;
        [SerializeField] TextMeshProUGUI cretitsText;

        private void Start()
        {
            cretitsText.text = creditsTextAsset.text;
        }
    }
}