using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise;

public class LD_Detect : MonoBehaviour
{
    public AK.Wwise.Event BlockEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SoundBarrier"))
        {
            BlockEvent.Post(gameObject);
            print("Wall");
        }
    }

}
