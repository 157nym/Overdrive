using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clicklevel : MonoBehaviour
{
    public ChangeMaterial material;
    public int level;
    public int cote;
    public GameObject boutton;
    // Start is called before the first frame update
    void Start()
    {
        level = material.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Changer()
    {
        if (boutton != null)
        {
            level = level + cote; 
        }
    }
}
