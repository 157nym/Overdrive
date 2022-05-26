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

    public int phase = 1;

    public float Timer;

    private int ChangeHeight;

    public float distanceMax;

    public bool goPhaseCalm;

    private int rampeIndex;

    public List<GameObject> activeTiles = new List<GameObject>();

    private void Awake()
    {
        tableauListeActuel = tileListeEasy; //Au lancement la diffculté est sur Easy
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnTile(0);
        SpawnTile(0);
        SpawnTile(0);
        SpawnTile(1);

        distanceMax = playerTransform.transform.position.z + 40;

        InvokeRepeating("PhaseCalm", 20, 30); // Au bout de X sec et toute les X sec il ya une phase Calm pour les PopUps qui dure 10s;
    }

    // Update is called once per frame
    void Update()
    {
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

        if (goPhaseCalm)
        {
            Timer -= Time.deltaTime;

            if (Timer <= 0)
            {
                goPhaseCalm = false;
                return;
            }
        }

        if (Time.time > 30 && Time.time <= 60 && !goPhaseCalm) // Passage à la phase 2
        {
            phase = 2;
        }

        if (Time.time > 60 && !goPhaseCalm) // Passage à la phase 3 au bout de x secondes
        {
            phase = 3;
        }

        if (playerTransform.transform.position.z >= distanceMax) // Si le player dépasse X distance on fait spawn une tile devant lui et ont supprime une tiles derrière lui
        {
            if(activeTiles.Count < maxTile) // on check s'il y a moin de tile présente que de tile maximum autorisé
            {
                int Verif = Random.Range(0, tableauListeActuel.Length);

                SpawnTile(Verif);
                distanceMax = playerTransform.transform.position.z + 40;
            }
        }
    }
    void SpawnTile(int tileIndex)
    {
        Vector3 pos;
        GameObject go; 

        if (activeTiles.Count >= 3 && rampeIndex <= 0) // Si ChangeHeight et = à 9 ou 10 alors on fait spawn une rampe sinon on fait spawn une tile normal
        {
            tileIndex = Random.Range(0,2);
            rampeIndex = Random.Range(4, 10);

            pos = transform.forward * zSpawn;
            pos.y = Hauteur * 19.5f;
            go = Instantiate(tileListeHeight[tileIndex], pos, transform.rotation);
            activeTiles.Add(go);
            zSpawn += tileLenght;

            DeleteTile();

            if(tileIndex == 0) // On vérifie si c'est une rampe qui monte ou qui descend
            {
                Hauteur++;
            }
            else
            {
                Hauteur--;
            }
            return;
        }

        pos = transform.forward * zSpawn;
        pos.y = Hauteur * 19.5f;
        go = Instantiate(tableauListeActuel[tileIndex], pos, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLenght;
        rampeIndex--;
        DeleteTile();
    }

    void PhaseCalm()
    {
        goPhaseCalm = true;
        Timer = 10;
        phase = 4;
    }

    void DeleteTile()
    {
        if(activeTiles.Count > maxTile - 1)
        {
            Destroy(activeTiles[0]);
            activeTiles.RemoveAt(0);
        }
    }
}
