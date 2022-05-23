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
        Mat.SetTexture("_BaseMap", Ads[Random.Range(0, Ads.Length)]);
    }


}
