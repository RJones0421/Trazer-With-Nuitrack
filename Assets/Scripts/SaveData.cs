using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData 
{

    public List<string> timeData = new List<string>();

    //Convert to Json String
    public string ToJson(){
        return JsonUtility.ToJson(this);
    }

    //Load from Json
    public void LoadFromJson(string a_Json){
        JsonUtility.FromJsonOverwrite(a_Json, this);
    }
}

//Inherit from ISaveable, takes instance of this class and
//fill it with whatever data you want to save/load
public interface ISaveable
{
    void PopulateSaveData(SaveData a_SaveData);
    void LoadFromSaveData(SaveData a_SaveData);
}
