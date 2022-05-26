using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPopUp : MonoBehaviour
{
    public RawImage[] popUp;

    public Transform target;

    public Canvas canvas;

    public float SpawnRate;

    public RectTransform rt;

    private GameManager Manager;


    public void Start()
    {
        Manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public IEnumerator SpawnPop() // On fait spawn un popUp avec un pos random situé a l'interieur d'un rect
    {
        float spawnX = Random.Range(rt.rect.xMax, rt.rect.xMin);
        float spawnY = Random.Range(rt.rect.yMax, rt.rect.yMin);

        Vector2 spawnPosition = new Vector2(spawnX,spawnY);

        RawImage Spawn = Instantiate(popUp[Random.Range(0,popUp.Length)], spawnPosition , Quaternion.identity, target.transform);
        Spawn.rectTransform.anchoredPosition = spawnPosition;
        Manager.Saturation++;
        yield return new WaitForSeconds(SpawnRate);
    }
}
