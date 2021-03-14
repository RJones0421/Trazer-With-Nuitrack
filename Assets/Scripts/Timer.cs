using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour, ISaveable
{
    [SerializeField] Text timeText;
    [SerializeField] Text scoreBoard;
    [SerializeField] Text score;

    public static Timer Instance;
    public GameObject overlay;
    private float timeTaken;
    private float[] times;
    private int count = 0;
    private bool timerActive;
    private float average = 0f;
    private int index = 0;

    void Awake(){
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive) {
            timeTaken += Time.deltaTime;
            DisplayTime();
        }
    }

    public void Save(){
        SaveJsonData(this);
    }

    public void Load(){
        LoadJsonData(this);
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
        foreach(var time in times) {
            average += time;
        }
        average /= times.Length;
        scoreBoard.text += "Average Time: " + average.ToString("F2");
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

    public void GameOver(){
        overlay.SetActive(true);
    }

    public void Clear(){
        count = 0;
        scoreBoard.text = "";
    }

    private static void SaveJsonData(Timer a_timer){
        SaveData sd = new SaveData();
        a_timer.PopulateSaveData(sd);
        if(FileManager.WriteToFile("SaveData.json", sd.ToJson()))
        {
            Debug.Log("Save Successful!");
        }
    }

     private static void LoadJsonData(Timer a_timer){
        
        if(FileManager.LoadFromFile("SaveData.json", out var json))
        {
            SaveData sd = new SaveData();
            sd.LoadFromJson(json);//Read from Json
            a_timer.LoadFromSaveData(sd);//Load
            Debug.Log("Load Complete");
        }
    }

    public void PopulateSaveData(SaveData a_SaveData){
        foreach (float data in times)
        {
            a_SaveData.timeData.Add(data);
        }
        a_SaveData.averageTimeData = average;
    }

    public void LoadFromSaveData(SaveData a_SaveData){
        int counter = 1;
        foreach (var time in a_SaveData.timeData)
        {
            score.text += "Time " + counter + ":" + time.ToString("F2") + "\n";
            counter += 1;
        }
        score.text += "Average time: " + a_SaveData.averageTimeData.ToString("F2") + "\n";
    }
}