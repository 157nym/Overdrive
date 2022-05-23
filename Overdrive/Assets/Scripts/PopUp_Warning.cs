using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp_Warning : MonoBehaviour
{
    public AK.Wwise.Event Beep;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) Beep.Post(gameObject);
    }
}
