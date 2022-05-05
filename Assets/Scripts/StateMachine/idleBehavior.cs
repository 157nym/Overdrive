using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleBehavior : StateMachineBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private float gravityValue = -9.81f;
    private Quaternion rotCamera;
    
    private GameObject Player;
    
    //Composant qui permet de faire bouger le joueur
    CharacterController characterController;

    //Rotation de la caméra
    float rotationX = 0;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            controller = Player.GetComponent<CharacterController>();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Player.transform.localScale = new Vector3(1,1,1);
        }
     
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            animator.SetBool("isRunning", true);
        }
        
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("isJumping", true);
        }
        
    }
    
    // override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
    //     
    // }

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
