using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int Life;
    public int Saturation;
    public int MaxSaturation;
    public int coins;
    public bool Paused = false;
    public GameObject PopUpManager,GameOverCanvas, MenuPause;
    public CharacterMovementAutoRun playerManager;
    public TextMeshProUGUI Décompte;
    private GameObject Hud;
    private Scene scene;
    private PlayableDirector Director;
    private float timeBeforePlay = 3;
    private bool Go = true;


    private void Start()
    {
        Hud = GameObject.FindGameObjectWithTag("HUD");
        scene = SceneManager.GetActiveScene(); 
        MenuPause.SetActive(Paused);
        PopUpManager.SetActive(!Paused);
        Director = GetComponent<PlayableDirector>();
        playerManager.forwardSpeed = 0;
        playerManager.speedAugmentation = 0;
    }

    public void Update()
    {
        if (timeBeforePlay < 1 && Go)
        {
            Décompte.text = "GO";
            playerManager.forwardSpeed = 25;
            playerManager.speedAugmentation = 0.0001f;
            Go = false;
            Décompte.gameObject.SetActive(false);
        }
        else
        {
            timeBeforePlay -= Time.deltaTime;
            Décompte.text = Mathf.Round(timeBeforePlay).ToString();
        }
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
        //GameOverCanvas.SetActive(true);
        Director.Play();
    }

    public void Restart()
    {
        SceneManager.LoadScene(scene.name);
    }

    public void Quitter()
    {
        Application.Quit();
    }
}
