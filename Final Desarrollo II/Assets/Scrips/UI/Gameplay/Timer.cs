
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public UnityEvent finishTime;

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
        else
        {
            finishTime.Invoke();
        }


    }



}
