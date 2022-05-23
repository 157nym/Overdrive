using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private Scene scene;

    private GameObject PopUpManager;

    private CharacterMovementAutoRun playerInfo;

    private GameObject player;

    private GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        PopUpManager = GameObject.FindGameObjectWithTag("PopUpManager");
        player = GameObject.FindGameObjectWithTag("Player");
        playerInfo = player.GetComponent<CharacterMovementAutoRun>();
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Spawn");
            //StartCoroutine(PopUpManager.GetComponent<SpawnPopUp>().SpawnPop());
            //playerInfo.NbrPop ++; 
            manager.Damage();
            other.gameObject.GetComponentInChildren<Animation>().Play();
            AkSoundEngine.PostEvent("Damage", player.gameObject);
        }
    }

}
