using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToGrid : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        SnapGrid();
    }

    private void SnapGrid()
    {
        Vector3 position = new Vector3(
            Mathf.RoundToInt(transform.position.x),
            Mathf.RoundToInt(transform.position.x),
            Mathf.RoundToInt(transform.position.z)
        );

        transform.position = position;
    }
}
