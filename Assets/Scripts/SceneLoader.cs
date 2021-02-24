using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{  

    //Load ConeDrill
    public void LoadGameConeDrill(){
        SceneManager.LoadScene(2);
    }
    //Load Main Menu
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }
    //Quit Application
    public void QuitGame(){
        Application.Quit();
        Debug.Log("Quit!");
    }
}
