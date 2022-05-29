using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    private Scene scene;
    public GameObject GameOverCanvas, MenuPause, MenuOption;

    public void Start()
    {
        scene = SceneManager.GetActiveScene();
    }
    public void Restart()
    {
        scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void Quitter()
    {
        Application.Quit();
    }

    public void Option()
    {
        MenuOption.SetActive(true);
        MenuPause.SetActive(false);
    }

    public void Return()
    {
        MenuOption.SetActive(false);
        MenuPause.SetActive(true);
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
