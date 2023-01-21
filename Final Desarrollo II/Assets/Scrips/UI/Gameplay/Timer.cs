
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timer;
    [SerializeField] float initialValueTimer;
    float currentTime;
    void Start()
    {
        currentTime = initialValueTimer;
        timer.text = "" + currentTime.ToString("f1");

    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            timer.text = "" + currentTime.ToString("f1");
        }


    }



}
