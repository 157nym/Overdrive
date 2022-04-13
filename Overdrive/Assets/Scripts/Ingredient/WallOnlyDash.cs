using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOnlyDash : MonoBehaviour
{
    public Dash playerInfoDash;
    private BoxCollider collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInfoDash.isDashing)
        {
            collider.enabled = playerInfoDash.isDashing;
            //Debug.Log("Joueur Dash");
        }

        else
        {
            collider.enabled = true;
        }
    }
}
