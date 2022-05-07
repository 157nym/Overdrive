using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] private float CoolDown, dashForce, CoolDownDashBool;
    [SerializeField] private bool CoolDownOK, coolDown;

    public bool isDashing;

    public CharacterController characterController;

    private Transform Cam;

    public float DashSpeed;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();

        Cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {


        if (CoolDown <= 0)
        {
            CoolDownOK = true;
        }
        else
        {
            CoolDown -= Time.deltaTime;
        }

        if (CoolDownOK == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                isDashing = true;
                Debug.Log("Joueur Dash");
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            DashForwardScript();
        }
    }

    public void DashForwardScript()
    {
        characterController.Move(Cam.forward * DashSpeed * Time.deltaTime);
        CoolDown = 1f;
        CoolDownOK = false;
        isDashing = false;
    }

}
