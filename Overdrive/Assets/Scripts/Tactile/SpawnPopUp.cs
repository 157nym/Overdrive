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
    // Update is called once per frame

    public void Start()
    {

    }

    public IEnumerator SpawnPop()
    {
        float spawnX = Random.Range(rt.rect.xMax, rt.rect.xMin);
        float spawnY = Random.Range(rt.rect.yMax, rt.rect.yMin);

        Vector2 spawnPosition = new Vector2(spawnX,spawnY);

        RawImage Spawn = Instantiate(popUp[0], spawnPosition , Quaternion.identity, target.transform);
        Spawn.rectTransform.anchoredPosition = spawnPosition;
        yield return new WaitForSeconds(SpawnRate);
    }
}
