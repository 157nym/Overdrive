using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatManager : MonoBehaviour
{
    public GameManager gameManager;
    public TileManager tileManager;
    public SpawnPopUp popUpManager;
    private Scene scene;

    void Start()
    {
        scene = SceneManager.GetActiveScene(); 
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("[1]"))
        {
            StartCoroutine(popUpManager.SpawnPop());
        }

        if(Input.GetKeyDown("[2]"))
        {
            tileManager.phase = 1;
        }

        if(Input.GetKeyDown("[3]"))
        {
            tileManager.phase = 2;
        }

        if(Input.GetKeyDown("[4]"))
        {
            tileManager.phase = 3;
        }

        if(Input.GetKeyDown("[5]"))
        {
            SceneManager.LoadScene(scene.name);
        }

        if(Input.GetKeyDown("[6]"))
        {
            gameManager.Death();
        }
    }
}
