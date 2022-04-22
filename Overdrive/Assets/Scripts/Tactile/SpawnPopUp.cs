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
    // Update is called once per frame

    public IEnumerator SpawnPop()
    {
        RawImage Spawn = Instantiate(popUp[0], target.position,target.rotation, canvas.transform);
        yield return new WaitForSeconds(SpawnRate);
    }
}
