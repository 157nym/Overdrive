using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Life;
    public int Saturation;
    public int MaxSaturation;
    public int coins;
    public bool Paused = false;
    public GameObject PopUpManager,GameOverCanvas, MenuPause;

    private GameObject Hud;

    private void Start()
    {
        Hud = GameObject.FindGameObjectWithTag("HUD");
    }

    public void PauseGame()
    {
        Paused = !Paused;
        MenuPause.SetActive(Paused);
        PopUpManager.SetActive(!Paused);

        if(Paused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        if (Saturation > MaxSaturation) Death();
    }

    public void Damage()
    {
        Hud.GetComponent<Life_Hud>().Damage();
        Life--;
        if (Life <= 0) Death();
    }


    public void Death()
    {
        Debug.Log("Dead");
        GameOverCanvas.SetActive(true);
    }
}
