using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    CharacterMovementAutoRun speeds;
    Text vitesse;
    public float PlayerScore;
    private GameManager Manager;


    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        vitesse = GetComponent<Text>();
        PlayerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        vitesse.text = "Score Corpo = " + PlayerScore.ToString("f1");
        if(Manager.GamePlaying) PlayerScore = PlayerScore + 1f*Time.deltaTime;
    }

}
