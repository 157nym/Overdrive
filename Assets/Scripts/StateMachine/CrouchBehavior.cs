using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchBehavior : StateMachineBehaviour
{
    private GameObject Player;
    private PlayerMouvement playerMouvement;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            playerMouvement = Player.GetComponent<PlayerMouvement>();
        }
        
        animator.SetBool("isCrouching", true);

        
        Vector3 objectScale = Player.transform.localScale;
        Player.transform.localScale = new Vector3(objectScale.x, objectScale.y / 10, objectScale.z);
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // if (!Input.GetButton("Crouch"))
        // {
        //     animator.SetBool("isSliding", false);
        // }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerMouvement.speedMultiplier = 1f;
        Player.transform.localScale = new Vector3(1, 1, 1);
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
