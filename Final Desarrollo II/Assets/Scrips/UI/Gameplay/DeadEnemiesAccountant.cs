using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeadEnemiesAccountant : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI enemiesCountText;
    int deadEnemiesAccountant;
    void Start()
    {
        deadEnemiesAccountant = 0;
        enemiesCountText.text = "" + deadEnemiesAccountant.ToString();

    }

    public void addToDeadEnemiesAccountant()
    {
        deadEnemiesAccountant++;
        enemiesCountText.text = "" + deadEnemiesAccountant.ToString();
    }

    public void SaveDeadEnemiesAccountantValue()
    {
        PlayerPrefs.SetInt("EnemiesKilled", deadEnemiesAccountant);
    }
}
