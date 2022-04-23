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
        float spawnX = rt.transform.position.x + Random.Range(-rt.gameObject.transform.position.x + popUp[0].rectTransform.rect.height/2, rt.gameObject.transform.position.x);
        float spawnY = rt.transform.position.y + Random.Range(-rt.gameObject.transform.position.y + popUp[0].rectTransform.rect.width/2, rt.gameObject.transform.position.y);

        Vector2 spawnPosition = new Vector2(spawnX,spawnY);

        RawImage Spawn = Instantiate(popUp[0], spawnPosition , Quaternion.identity, target.transform);
        yield return new WaitForSeconds(SpawnRate);
    }
}
