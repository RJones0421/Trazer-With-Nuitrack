using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour, ISaveable
{
    public static Timer Instance;
    public Text timeText;
    public Text scoreBoard;
    public float startTime;
    public bool timerActive;
    public List<string> time = new List<string>();
    
    private void Awake(){
        Instance = this;
        startTime = 60;
    }

    // Start is called before the first frame update
    void Start()
    {
        timerActive = true;
        LoadJsonData(this);
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
            else
            {
                Debug.Log("Time is up!");
                startTime = 0;
                timerActive = false;
                Save();
            }
        }
    }

    public void Save(){
        SaveJsonData(this);
    }

    public void Add(){
        time.Add(startTime.ToString("F2"));
        Debug.Log("Adding time!");
    }

    void DisplayTime(){
        timeText.text = startTime.ToString("F2");
    }

    /*
    Save and Load Data
    */
    private static void SaveJsonData(Timer a_timer){
        SaveData sd = new SaveData();
        //sd.timeData = a_timer.startTime
        a_timer.PopulateSaveData(sd);

        if(FileManager.WriteToFile("SaveData.dat", sd.ToJson()))
        {
            Debug.Log("Save Successful!");
        }
    }

    public void PopulateSaveData(SaveData a_SaveData){

        foreach (string data in time)
        {
            a_SaveData.timeData.Add(data);
        }
    }
    
    private static void LoadJsonData(Timer a_timer){
        
        if(FileManager.LoadFromFile("SaveData.dat", out var json))
        {
            SaveData sd = new SaveData();
            sd.LoadFromJson(json);//Read from Json
            a_timer.LoadFromSaveData(sd);//Load
            Debug.Log("Load Complete");
        }
    }

    public void LoadFromSaveData(SaveData a_SaveData){

        foreach (var time in a_SaveData.timeData)
        {
            scoreBoard.text += time + "\n";
        }
    }
}

