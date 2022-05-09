using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CloseButton : MonoBehaviour
{
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Close()
    {
        Destroy(parent);
    }
}
