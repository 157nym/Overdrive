using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Material[] MyMaterial;
    public int x;
    Renderer rend;
    
    
    void Start()
    {
        
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial= MyMaterial[x];
        
    }

    // Update is called once per frame
    void Update()
    {
        rend.sharedMaterial = MyMaterial[x];
        
        
        

    }

    public void plusMaterial()
    {
        x = x + 1;
        
        if (x > 4)
        {
            x = 0;
        }
    }

    
    public void moinsMaterial()
    {
        x = x - 1;
        if (x < 0)
        {
            x = 4;
        }
        
    }
}
