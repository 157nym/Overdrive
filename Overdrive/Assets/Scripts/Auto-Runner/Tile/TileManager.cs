using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tileListeEasy;

    public GameObject[] tileListeMedium;

    public GameObject[] tileListeHard;

    public GameObject[] tileListeCalm;

    public GameObject[] tileListeHeight;

    public GameObject[] tableauListeActuel;

    public float zSpawn = 50;

    public float tileLenght = 30;

    public Transform playerTransform;

    public int Hauteur = 0;

    public int maxTile;

    private int phase = 1;

    public float SpawntileTime;

    private List<GameObject> activeTiles = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        SpawnTile(0);
        SpawnTile(0);
        SpawnTile(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(phase == 1)
        {
            tableauListeActuel = tileListeEasy;
        }

        if (phase == 2)
        {
            tableauListeActuel = tileListeMedium;
        }

        if (phase == 3)
        {
            tableauListeActuel = tileListeHard;
        }

        if (phase == 4)
        {
            tableauListeActuel = tileListeHeight;
        }

        if (phase == 5)
        {
            tableauListeActuel = tileListeCalm;
        }

        SpawntileTime -= Time.deltaTime;

        if (activeTiles.Count < maxTile)
        {
            if(SpawntileTime <= 0)
            {
                
                int Verif = Random.Range(0, tableauListeActuel.Length);

                SpawnTile(Verif);

                if (Verif == 0 && phase == 4)
                {
                    Hauteur += 1;
                    phase = 1;
                    int ram = Random.Range(0, tableauListeActuel.Length);
                    SpawnTile(ram);
                }

                if (Verif == 1 && phase == 4)
                {
                    Hauteur -= 1;
                    phase = 1;
                    int ram = Random.Range(0, tableauListeActuel.Length);
                    SpawnTile(ram);
                }

                SpawntileTime = 0.8f;
            }
        }

        else
        {
            DeleteTile();
        }
    }
    void SpawnTile(int tileIndex)
    {
        Vector3 pos = transform.forward * zSpawn;
        pos.y = Hauteur * 10;
        GameObject go = Instantiate(tableauListeActuel[tileIndex], pos, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLenght;
    }

    void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
