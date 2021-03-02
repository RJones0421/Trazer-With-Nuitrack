using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{  

    //Load Leaderboards
    public void LoadLeaderboards(){
        SceneManager.LoadScene(3);
    }
    //Load ConeDrill
    public void LoadGameConeDrill(){
        SceneManager.LoadScene(2);
    }
    //Load Main Menu
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }
    //Load Login Menu
    public void LoadLoginMenu()
    {
        SceneManager.LoadScene(0);
    }
    //Quit Application
    public void QuitGame(){
        Application.Quit();
        Debug.Log("Quit!");
    }
}
