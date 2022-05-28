using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Pic : MonoBehaviour
{
    private Material Mat;

    public Texture[] Ads;

    private void Start()
    {
        Mat = GetComponent<Renderer>().materials[1];
        //choose a random sprite from Ads
        Texture AD = Ads[Random.Range(0, Ads.Length)];
        Mat.SetTexture("_BaseMap", AD);
        Mat.SetTexture("_EmissionMap", AD);
    }
}
