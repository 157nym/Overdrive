using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class speedcounter : MonoBehaviour
{
    CharacterMovementAutoRun speeds;
    Text vitesse;
    public float vitessejoueur;


    // Start is called before the first frame update
    void Start()
    {

        vitesse = GetComponent<Text>();
        vitessejoueur = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
        vitesse.text = "Speed = " + vitessejoueur.ToString("f2") + " km/h";

        vitessejoueur = vitessejoueur + 0.01f*Time.deltaTime;
    }

}
