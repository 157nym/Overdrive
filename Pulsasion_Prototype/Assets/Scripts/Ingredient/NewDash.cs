using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDash : MonoBehaviour
{
    public PlayerMouvement playerInfo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInfo.CoolDownOK = true;
            Destroy(gameObject);
        }
    }
}
