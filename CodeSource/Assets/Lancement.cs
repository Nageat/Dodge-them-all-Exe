using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class Lancement : MonoBehaviour
{

    public string scene;
    public string sceneH;

    public void lancejeuH()
    {
        SceneManager.LoadScene(sceneH, LoadSceneMode.Single);
    }
    public void lancejeu()
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
    public void exitgame() {  
        Debug.Log("exitgame");  
        Application.Quit();  
    } 
}
