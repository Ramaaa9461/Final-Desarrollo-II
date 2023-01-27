using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreditsParser : MonoBehaviour
{

   [SerializeField] TextAsset creditsTextAsset;
   [SerializeField] TextMeshProUGUI cretitsText;

    private void Start()
    {
        cretitsText.text = creditsTextAsset.text;


    }




}
