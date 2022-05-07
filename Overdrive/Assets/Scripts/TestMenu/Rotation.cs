using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float speed;
    private Vector3 rotation;
    void Start()
    {
        rotation = Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation *speed* Time.deltaTime);
    }
}
