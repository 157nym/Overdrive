using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPopUp : MonoBehaviour
{
    public RawImage[] popUp;

    public Transform target;

    public Canvas canvas;
    // Update is called once per frame
    void Update()
    {
        Invoke("PopUp",3);
    }

    void PopUp()
    {
        RawImage Spawn = Instantiate(popUp[0], target.position,target.rotation);
    }
}
