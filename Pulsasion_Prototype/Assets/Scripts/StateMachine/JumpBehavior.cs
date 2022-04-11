using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBehavior : StateMachineBehaviour
{
    
    private CharacterController controller;
    private Vector3 playerVelocity;
    public bool groundedPlayer;
    private float playerSpeed = 2.0f;
    public float jumpHeight = 5.0f;
    private float gravityValue = -9.81f;

    private int jump;
    
    
    public float jumpSpeed = 8f;
    //Déplacement
    Vector3 moveDirection;
    float gravity = 20f;
    
    private GameObject Player;
    //Composant qui permet de faire bouger le joueur
    CharacterController characterController;
    // Y = axe haut/bas
    private float speedY;


    private RaycastHit HitR;

    private RaycastHit HitL;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            controller = Player.GetComponent<CharacterController>();
            
            // Y = axe haut/bas
            speedY = moveDirection.y;
        }
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        moveDirection.y = jumpSpeed;
        //Applique le mouvement
        controller.Move(moveDirection * Time.deltaTime);

            if(Physics.Raycast(Player.transform.position, -Player.transform.right, out HitL, 1))
            {
                if(HitL.transform.gameObject.CompareTag ("wall"))
                {
                    animator.SetBool("isWallRunning", true);
                }   
            }
            if(Physics.Raycast(Player.transform.position, Player.transform.right, out HitR, 1))
            {
                if(HitR.transform.gameObject.CompareTag ("wall"))
                {
                    animator.SetBool("isWallRunning", true);
                }   
            }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
