using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int coins;
    public bool Paused = false;
    public GameObject Continue, Menu, Option, PopUpManager;
    // Start is called before the first frame update
    public void PauseGame()
    {
        Paused = !Paused;

        Continue.SetActive(Paused);
        Menu.SetActive(Paused);
        Option.SetActive(Paused);
        PopUpManager.SetActive(!Paused);

        if(Paused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

    }
}
