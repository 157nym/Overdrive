using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private Scene scene;

    private GameObject PopUpManager;

    private GameManager Manager;

    private GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        PopUpManager = GameObject.FindGameObjectWithTag("PopUpManager");
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        Manager = gameManager.GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Spawn");
            StartCoroutine(PopUpManager.GetComponent<SpawnPopUp>().SpawnPop());
            other.gameObject.GetComponentInChildren<Animation>().Play();
            Manager.NbrPop ++;
        }
    }
}
