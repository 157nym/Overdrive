using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp_Spawner : MonoBehaviour
{
    public int PopUpNumber;

    private GameObject PopUpManager;


    private void Awake()
    {
        PopUpManager = GameObject.FindGameObjectWithTag("PopUpManager");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(SpawnPopUp());
        }
    }

    IEnumerator SpawnPopUp()
    {
        //Debug.Log("Spawning");
        for(int i = 0; i < PopUpNumber; i++)
        {
            StartCoroutine(PopUpManager.GetComponent<SpawnPopUp>().SpawnPop());
            yield return new WaitForSeconds(Random.Range(0,0.2f));
        }
    }
}
