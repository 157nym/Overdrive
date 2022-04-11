using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawn : MonoBehaviour
{
    public GameObject platform;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
       // rb = platform.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            rb.useGravity = true;
            
        }
    }
}
