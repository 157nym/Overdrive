using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallRunningBehavior : StateMachineBehaviour
{
    private bool isWallR = false;
    private bool isWallL = false;
    private RaycastHit HitR;

    private RaycastHit HitL;
    private int jumpCount = 0;
    private PlayerMouvement playerMouvement;
    private Rigidbody rb;
    public float runTime = 0.5f;
    private CharacterController controller;
    private GameObject Player;

    private float baseGravity;

    private bool plusMur;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            controller = Player.GetComponent<CharacterController>();
            playerMouvement = Player.GetComponent<PlayerMouvement>();
            rb = Player.GetComponent<Rigidbody>();
        }

        baseGravity = playerMouvement.gravity;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(playerMouvement.characterController.isGrounded)
        {
            jumpCount = 0;
        }

        if(!playerMouvement.characterController.isGrounded && jumpCount <= 1)
        {
            if(Physics.Raycast(Player.transform.position, -Player.transform.right, out HitL, 1))
            {
                if(HitL.transform.gameObject.CompareTag ("wall"))
                {
                    isWallL = true;
                    isWallR = false;
                    //jumpCount += 1;
                    rb.useGravity = false;
                    playerMouvement.gravity =- baseGravity;
                }

                Debug.Log(HitL.transform.gameObject.name);
            }

            if(Physics.Raycast(Player.transform.position, Player.transform.right, out HitR, 1))
            {
                if(HitR.transform.gameObject.CompareTag ("wall"))
                {
                    isWallR = true;
                    isWallL = false;
                    //jumpCount += 1;
                    rb.useGravity = false;
                    playerMouvement.gravity =- baseGravity;
                }
            }
        }

        animator.SetBool("isWallRunning", plusMur);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        isWallL = false;
        isWallR = false;
        rb.useGravity = true;
        playerMouvement.gravity = baseGravity;

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
