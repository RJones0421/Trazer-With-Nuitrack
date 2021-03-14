using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{  
    public int sceneValue;

    //Load scene
    public void LoadScene(int num){
        SceneManager.LoadScene(num);
        Debug.Log("Loading scene");
    }
    
    //Quit Application
    public void QuitGame(){
        Application.Quit();
        Debug.Log("Quit!");
    }
}
