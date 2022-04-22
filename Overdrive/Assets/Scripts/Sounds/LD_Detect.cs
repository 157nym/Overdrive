using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise;

public class LD_Detect : MonoBehaviour
{
    public AK.Wwise.Event BlockWall;
    public AK.Wwise.Event BlockJump;
    public AK.Wwise.Event BlockSlide;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BlockWall"))
        {
            BlockWall.Post(other.gameObject);
            print("Wall");
        }

        if (other.CompareTag("BlockJump"))
        {
            BlockJump.Post(other.gameObject);
        }

        if (other.CompareTag("BlockSlide"))
        {
            BlockSlide.Post(other.gameObject);
        }
    }

}
