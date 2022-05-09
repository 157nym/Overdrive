using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    CharacterMovementAutoRun speeds;
    Text vitesse;
    public float vitessejoueur;


    // Start is called before the first frame update
    void Start()
    {

        vitesse = GetComponent<Text>();
        vitessejoueur = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        vitesse.text = "Score Corpo = " + vitessejoueur.ToString("f1");

        vitessejoueur = vitessejoueur + 1f*Time.deltaTime;
    }

}
