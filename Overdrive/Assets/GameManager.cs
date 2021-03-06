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
    public GameObject PopUpManager,GameOverCanvas, MenuPause, MenuOption;
    public CharacterMovementAutoRun playerManager;
    public TextMeshProUGUI Décompte;
    private GameObject Hud;
    private PlayableDirector Director;
    //private float timeBeforePlay = 3;
    //private bool Go = true;
    public float playerBaseSpeed;
    public bool GamePlaying = false;


    private void Start()
    {
        Hud = GameObject.FindGameObjectWithTag("HUD");
        MenuPause.SetActive(Paused);
        PopUpManager.SetActive(!Paused);
        Director = GetComponent<PlayableDirector>();
        playerManager.forwardSpeed = 0;
        playerManager.speedAugmentation = 0;
    }

    public void Update()
    {
        //if (timeBeforePlay < 1 && Go)
        //{
        //    Go = false;
        //    playerManager.forwardSpeed = 25;
        //    playerManager.speedAugmentation = 0.0001f;
        //    Décompte.gameObject.SetActive(false);
        //    playerManager.sound.MusicStart();
        //}
        //else
        //{
        //    timeBeforePlay -= Time.deltaTime;
        //    Décompte.text = Mathf.Round(timeBeforePlay).ToString();
        //}

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void StartGame()
    {
        //Go = false;
        playerManager.forwardSpeed = playerBaseSpeed;
        playerManager.speedAugmentation = 0.0001f;
        //Décompte.gameObject.SetActive(false);
        playerManager.sound.MusicStart();
        GamePlaying = true;
    }

    public void PauseGame() // Fonction appeler si le joueur appuie sur le bouton "Pause"
    {
        if (!GamePlaying) return;
        
        Paused = !Paused;
        MenuPause.SetActive(Paused);
        PopUpManager.SetActive(!Paused);
        
        if (Paused)
        {
            Time.timeScale = 0;
            playerManager.GetComponent<CharacterSound>().PauseGame();
        }
        else
        {
            Time.timeScale = 1;
            MenuOption.SetActive(false);
            playerManager.GetComponent<CharacterSound>().ResumeGame();
        }
        
        if (Saturation > MaxSaturation) Death(); // Condition de défaite
    }

    public void Damage() // Gestion et affichage des point de vie
    {
        Hud.GetComponent<Life_Hud>().Damage();
        Life--;
        if (Life <= 0) Death();
    }


    public void Death()
    {
        Debug.Log("Dead");
        Director.Play();
        GamePlaying = false;
    }
}
