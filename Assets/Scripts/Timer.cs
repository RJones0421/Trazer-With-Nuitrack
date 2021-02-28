using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timeText;
    public float startTime;
    bool timerActive = true;
    
    // Start is called before the first frame update
    void Start()
    {
        timeText.text = startTime.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        if(timerActive)
        {
            startTime += Time.deltaTime;
            timeText.text = startTime.ToString("F2");
        }
    }
}
