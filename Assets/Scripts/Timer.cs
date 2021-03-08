using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text timeText;
    [SerializeField] Text scoreBoard;

    private float timeTaken;
    private float[] times;
    private int count = 0;
    private bool timerActive;

    // Update is called once per frame
    void Update()
    {
        if (timerActive) {
            timeTaken += Time.deltaTime;
            DisplayTime();
        }
    }

    public void InstantiateTimes(int numTests) {
        times = new float[numTests];
    }

    public void StartTime()
    {
        timerActive = true;
        timeTaken = 0;
    }

    public void StopTime()
    {
        timerActive = false;
        RecordTime();
    }

    public void AverageTime() {
        float avgTime = 0f;
        foreach(var time in times) {
            avgTime += time;
        }
        avgTime /= times.Length;

        scoreBoard.text += "Average Time: " + avgTime.ToString("F2");
    }

    private void DisplayTime()
    {
        timeText.text = timeTaken.ToString("F2");
    }

    private void RecordTime()
    {
        times[count] = timeTaken;
        count++;
        scoreBoard.text += "Cone " + count + ": " + timeTaken.ToString("F2") + "\n";
    }
}