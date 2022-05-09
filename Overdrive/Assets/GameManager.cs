using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float timeBeforePlay;

    public bool PauseYes;
    public Text scoreTxt;
    private float score = 1;
    public float PointPerSecond;
    public int NbrPop;

    public float Multiply = 0.001f;

    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PointPerSecond += Multiply;
        
        score += PointPerSecond * Time.deltaTime;

        scoreTxt.text = "Score : " + Mathf.RoundToInt(score);

        if(NbrPop >= 10)
        {
            SceneManager.LoadScene("Auto_Runner_Lvl");
        }

        if(timeBeforePlay < 3)
        {
            Paused();
        }
        else
        {
            Unpaused();
        }

        if(PauseYes)
        {
            Paused();
        }
        else
        {
            Unpaused();
        }
    }

    void Paused()
    {
        Time.timeScale = 0;
    }

    void Unpaused()
    {
        Time.timeScale = 1;
    }
}
