using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise;

public class LD_Detect : MonoBehaviour
{
    public AK.Wwise.Event BlockEvent;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SoundBarrier"))
        {
            if(anim != null)
            {
                anim.SetFloat("Speed", (other.gameObject.GetComponentInParent<CharacterMovementAutoRun>().DuréeAnim * 2));
                anim.SetTrigger("Flash");
            }
            if(other.GetComponentInParent<CharacterMovementAutoRun>().forwardSpeed > 5) BlockEvent.Post(gameObject);
            //print(BlockEvent.Name);
        }
    }

}
