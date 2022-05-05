using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;

    private GameObject[] TileNombre;

    public float zSpawn = 50;

    public float tileLenght = 30;

    public Transform playerTransform;

    public int Hauteur = 0;

    public int maxTile;

    private List<GameObject> activeTiles = new List<GameObject>(); 
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i <= maxTile; i++)
        {
            if (i == 0)
            {
                SpawnTile(0);
            }

            else
            {
                int Verif = Random.Range(0,tilePrefabs.Length);

                SpawnTile(Verif);
                
                if(Verif == 5)
                {
                    Hauteur += 1;
                    int ram = Random.Range(0,4);
                    SpawnTile(ram);
                }

                if(Verif == 6)
                {
                    Hauteur -= 1;
                    int ram = Random.Range(0,4);
                    SpawnTile(ram);
                }
                
                if (Verif == 7)
                {
                    Hauteur += 1;
                    Split(1);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - 35 > zSpawn-(tilePrefabs.Length * tileLenght))
        {
                int Verif = Random.Range(0,tilePrefabs.Length);

                SpawnTile(Verif);

                if(Verif == 5)
                {
                    Hauteur += 1;
                    int ram = Random.Range(0,4);
                    SpawnTile(ram);
                }

                if(Verif == 6)
                {
                    Hauteur -= 1;
                    int ram = Random.Range(0,4);
                    SpawnTile(ram);
                }

                if (Verif == 7)
                {
                    Hauteur += 1;
                    Split(1);
                }
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

    public void Split(int tileIndex)
    {
        Vector3 pos = transform.forward * zSpawn;
        pos.y = Hauteur * 10;
        GameObject go = Instantiate(tilePrefabs[tileIndex], pos, transform.rotation);
        activeTiles.Add(go);

        Vector3 pos2 = transform.forward;
        pos.y = Hauteur;
        GameObject go2 = Instantiate(tilePrefabs[tileIndex], pos2, transform.rotation);
        activeTiles.Add(go2);
        zSpawn += tileLenght;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
