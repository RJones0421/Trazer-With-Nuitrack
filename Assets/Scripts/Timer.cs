using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour, ISaveable
{
    [SerializeField] Text timeText;
    [SerializeField] Text scoreBoard;
    [SerializeField] Text score;
    [SerializeField] Text speedScore;
    [SerializeField] Text previousScore;

    [SerializeField] Text conesLeft;
    [SerializeField] GameObject Avatar;

    [SerializeField] GameObject scripts;

    public static Timer Instance;
    public GameObject overlay;
    
    private string newLine = "\n";
    private float timeTaken;
    private float[] times;
    private int count = 0;
    private bool timerActive;
    private float averageTime = 0f;

    private float totalTime = 0f;
    //Speed variables
    public float distanceInMeters;

    public float totalDistanceTraveled;

    public int numberOfCones;
    private float speed = 0f;
    private float feetFactor = 3.28f;//Factor for conversion from m to ft
    private float[] speeds;
    private int index = 0;
    private float averageSpeed = 0f;
    
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

    //Json Functions
    public void Save(){
        SaveJsonData(this);
    }

    public void Load(){
        LoadJsonData(this);
    }

    //Timer
    public void InstantiateTimes(int numTests) {
        times = new float[numTests];
    }

    public void InstantiateSpeeds(int numTests){
        speeds = new float[numTests];
    }

       private void DisplayTime()
    {
        timeText.text = timeTaken.ToString("F2") + "\n";
    }

    public void DisplayConesLeft(){
        conesLeft.text = "Cones Left: " + numberOfCones.ToString();
    }

    public void UpdateNumberOfCones()
    {
        numberOfCones--;
    }

    public void StartTime()
    {
        timerActive = true;
        timeTaken = 0;
    }

       private void RecordTime()
    {
        times[count] = timeTaken;
        count++;
        scoreBoard.text += "Cone " + count + ": " + timeTaken.ToString("F2") + "s" + "\n";
    }

    public void StopTime()
    {
        timerActive = false;
        RecordTime();
    }

    public void Speed(){
        CalculateSpeed();
    }

    public void AverageTime() {
        foreach(var time in times) {
            averageTime += time;
        }
        averageTime /= times.Length;
        scoreBoard.text += "Average Time: " + averageTime.ToString("F2") + "s" + "\n";
    }

    public void TotalTime(){
        foreach(var time in times){
            totalTime += time;
        }
    }
 
    public void CalculateSpeed(){
        speed = (distanceInMeters * feetFactor) / timeTaken;
        speeds[index] = speed;
        index++;
        speedScore.text += "Speed in ft/s: " + speed.ToString("F2") + "\n";
    }

    public void AverageSpeed(){
        foreach(var s in speeds){
            averageSpeed += s;
        }
        averageSpeed /= speeds.Length;
        speedScore.text += "Average Speed: " + averageSpeed.ToString("F2") + " ft/s" + "\n";
    }

    public void CalculateTotalDistanceTraveled(){
        totalDistanceTraveled += distanceInMeters * feetFactor;
    }
 
    //Restart
    public void GameOver(){
        timeText.text = "";
        conesLeft.text = "";
        speedScore.text = "";
        scoreBoard.text = "";
        previousScore.text = "";
        score.text = "";
        overlay.SetActive(true);
        Avatar.SetActive(false);
    }
    
    public void Clear(){
        count = 0;
        index = 0;
        scoreBoard.text = "";
        speedScore.text = "";
        score.text = "";
        previousScore.text = "";
    }

    //Json
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
        a_SaveData.averageTimeData = averageTime;
        foreach(float data in speeds)
        {
            a_SaveData.speedData.Add(data);
        }
        a_SaveData.averageSpeedData = averageSpeed;
        a_SaveData.totalDistance = totalDistanceTraveled; 
        a_SaveData.totalTimeElapsed = totalTime;
    }

    public void LoadFromSaveData(SaveData a_SaveData){
        int counter = 1;
        previousScore.text += "Previous Times:" + newLine;
        foreach (var time in a_SaveData.timeData)
        {
            score.text += "Cone " + counter + ": time " + time.ToString("F2") + "s" + "\n";
            previousScore.text += "Cone " + counter + ": time " + time.ToString("F2") + "s" + newLine;
            counter += 1;
        }
        score.text += newLine + "Average time: " + a_SaveData.averageTimeData.ToString("F2") + " seconds" + "\n";
        score.text += newLine + "Average speed: " + a_SaveData.averageSpeedData.ToString("F2") + " ft/s" + "\n";
        score.text += newLine + "Total Distance Traveled: " + a_SaveData.totalDistance.ToString("F2") + " feet" + "\n";
        score.text += newLine + "Total time: " + a_SaveData.totalTimeElapsed.ToString("F2") + " seconds" +  "\n";
        previousScore.text += newLine + "Total time: " + a_SaveData.totalTimeElapsed.ToString("F2") + " seconds" +  "\n";
    }

    public void OnExit(){
        Destroy(scripts);
    }

}