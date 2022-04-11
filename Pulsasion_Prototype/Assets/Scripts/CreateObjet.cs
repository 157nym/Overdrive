using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjet : MonoBehaviour
{
    public GameObject Objetacreer;
    public Transform spawner;
    public float CTime = -1f;
    public float rate;

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E) && Time.time >CTime)
        {
            create();
        }
    }

    void create()
    {
        CTime = Time.time + rate;
        Vector3 rotationobjet = Vector3.up;
        Instantiate(Objetacreer, spawner.position, Quaternion.identity);
    }
}
