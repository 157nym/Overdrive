using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBuilding : MonoBehaviour
{
    public GameObject[] Buildings;

    public bool AlwaysSpawn;
    void Start()
    {
        int i;
        if (AlwaysSpawn)
        {
            i = Random.Range(0, Buildings.Length);
        }
        else
        {
            i = Random.Range(0, Buildings.Length + 1);
        }

        if(i < Buildings.Length)
        {
            Buildings[i].SetActive(true);
        }
    }
}
