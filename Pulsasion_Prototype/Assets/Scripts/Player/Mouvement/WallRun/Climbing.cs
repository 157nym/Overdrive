using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour
{
    private bool isWallR = false;
    private bool isWallL = false;
    private RaycastHit HitR;

    private RaycastHit HitL;
    private int jumpCount = 0;
    private PlayerMouvement cc;
    private Rigidbody rb;
    public float runTime = 0.5f;


    void Start()
    {
        cc = GetComponent<PlayerMouvement>();
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if(cc.characterController.isGrounded)
        {
            jumpCount = 0;
        }

        //HitR.transform.gameObject.CompareTag ("wall")

        if(!cc.characterController.isGrounded && jumpCount <= 1)
        {
            if(Physics.Raycast(transform.position, -transform.right, out HitL, 1))
            {
                if(HitL.transform.gameObject.CompareTag ("wall"))
                {
                    isWallL = true;
                    isWallR = false;
                    jumpCount += 1;
                    rb.useGravity = false;
                    cc.gravity = -20;
                    StartCoroutine (afterRun());
                }   
            }

            if(Physics.Raycast(transform.position, transform.right, out HitR, 1))
            {
                if(HitR.transform.gameObject.CompareTag ("wall"))
                {
                    isWallL = true;
                    isWallR = false;
                    jumpCount += 1;
                    rb.useGravity = false;
                    cc.gravity = -20;
                    StartCoroutine (afterRun()); 
                }
            }
        }
    }

    IEnumerator afterRun()
    {
        yield return new WaitForSeconds(runTime);
        isWallL = false;
        isWallR = false;
        rb.useGravity = true;
        cc.gravity = 20;
    }

}