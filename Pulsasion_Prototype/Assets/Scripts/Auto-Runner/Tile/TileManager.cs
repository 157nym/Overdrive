using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;

    public float zSpawn = 50;

    public float tileLenght = 30;
    // Start is called before the first frame update
    void Start()
    {
        SpawnTile(0);
        SpawnTile(1);
        SpawnTile(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTile(int tileIndex)
    {
        Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        zSpawn += tileLenght;
    }
}
