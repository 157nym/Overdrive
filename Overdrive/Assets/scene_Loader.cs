using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_Loader : MonoBehaviour
{
    public string GameScene;
    public void StartGame()
    {
        //Load GameScnene
        SceneManager.LoadScene(GameScene, LoadSceneMode.Additive);
    }
    
    public void closeScene()
    {
        //close current scene
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
