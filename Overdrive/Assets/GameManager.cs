using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool Paused = false;
    public GameObject Continue, Menu, Option;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PauseGame()
    {
        Debug.Log("ifdrs");
        Paused = !Paused;

        Continue.SetActive(Paused);
        Menu.SetActive(Paused);
        Option.SetActive(Paused);

    }
}
