using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;

    public float zSpawn = 50;

    public float tileLenght = 30;

    public Transform playerTransform;

    public int Hauteur = 0;

    public int maxTile;

    private List<GameObject> activeTiles = new List<GameObject>(); 
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxTile; i++)
        {
            if (i == 0)
            {
                SpawnTile(0);
            }

            else if (i == 5)
            {
                SpawnTile(5);
                Hauteur += 1 ;
            }

            else
            {
                SpawnTile(Random.Range(0, tilePrefabs.Length - 1));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (playerTransform.position.z - 35 > zSpawn-(tilePrefabs.Length* tileLenght))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length - 1));
            DeleteTile();
        }
    }

    public void SpawnTile(int tileIndex)
    {
        Vector3 pos = transform.forward * zSpawn;
        pos.y = Hauteur * 10;
        GameObject go = Instantiate(tilePrefabs[tileIndex], pos, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLenght;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
