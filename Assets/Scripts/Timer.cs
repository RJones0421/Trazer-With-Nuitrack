using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timeText;
    public Text scoreBoard;
    public float startTime = 60;
    public int count = 1;
    public bool timerActive;
    
    // Start is called before the first frame update
    void Start()
    {
        timerActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerActive)
        {
            if(startTime > 0)
            {
                startTime -= Time.deltaTime;
                DisplayTime();
            }
        }
        else
        {
            Debug.Log("Time is up!");
            startTime = 0;
            timerActive = false;
        }
    }

    void DisplayTime(){
        timeText.text = startTime.ToString("F2");
    }

    public void RecordTime(){
        scoreBoard.text += "Cone " + count + ": " + startTime.ToString("F2") + "\n";
        count += 1;
    }
}

