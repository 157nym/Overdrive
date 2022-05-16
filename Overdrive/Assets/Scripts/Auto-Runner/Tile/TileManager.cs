using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tileListeEasy;

    public GameObject[] tileListeMedium;

    public GameObject[] tileListeHard;

    public GameObject[] tileListeCalm;

    public GameObject[] tableauListeActuel;

    public float zSpawn = 50;

    public float tileLenght = 30;

    public Transform playerTransform;

    public int Hauteur = 0;

    public int maxTile;

    private int phase = 1;

    public float SpawntileTime, Timer, destroyTileTime;

    private List<GameObject> activeTiles = new List<GameObject>();

    private void Awake()
    {
        tableauListeActuel = tileListeEasy;
    }

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
        SpawntileTime -= Time.deltaTime;
        destroyTileTime -= Time.deltaTime;
        Timer = Time.time;

        if (phase == 1)
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
            tableauListeActuel = tileListeCalm;
        }

        if(Time.time > 30 && Time.time <= 60)
        {
            phase = 2;
        }

        if (Time.time > 90 && Time.time <= 120)
        {
            phase = 3;
        }

        if (SpawntileTime <= 0)
        {
            if(activeTiles.Count < maxTile) 
            {
                
                int Verif = Random.Range(0, tableauListeActuel.Length);
                SpawntileTime = 0.3f;

                SpawnTile(Verif);
            }
        }

        if(destroyTileTime <= 0)
        {
            DeleteTile();
            destroyTileTime = 1.5f;
        }
    }
    void SpawnTile(int tileIndex)
    {
        Debug.Log(tileIndex);
        Vector3 pos = transform.forward * zSpawn;
        pos.y = Hauteur * 10;
        GameObject go = Instantiate(tableauListeActuel[tileIndex], pos, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLenght;


        if (tileIndex == 9)
        {
            Hauteur += 1;
            //int ram = Random.Range(0, tableauListeActuel.Length-2);
            //SpawnTile(ram);
        }

        if (tileIndex == 10)
        {
            Hauteur -= 1;
            //int ram = Random.Range(0, tableauListeActuel.Length-2);
            //SpawnTile(ram);
        }
    }

    void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
