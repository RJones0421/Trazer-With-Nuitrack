using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text timeText;
    [SerializeField] Text scoreBoard;

    private float timeTaken;
    private int count = 1;
    private bool timerActive;

    // Update is called once per frame
    void Update()
    {
        if (timerActive) {
            timeTaken += Time.deltaTime;
            DisplayTime();
        }
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

    private void DisplayTime()
    {
        timeText.text = timeTaken.ToString("F2");
    }

    private void RecordTime()
    {
        scoreBoard.text += "Cone " + count + ": " + timeTaken.ToString("F2") + "\n";
        count += 1;
    }
}