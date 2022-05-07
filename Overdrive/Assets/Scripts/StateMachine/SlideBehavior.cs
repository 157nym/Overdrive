using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideBehavior : StateMachineBehaviour
{
    [SerializeField] private bool CanStand;
    private CharacterController controller;
    private PlayerMouvement playerMouvement;
    public float Temps, TempsquiAvance, vitesseActuel;

    private float playerSpeed = 0.2f;

    private GameObject Player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isCrouching", false);
        TempsquiAvance = 0;
        
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            controller = Player.GetComponent<CharacterController>();
            playerMouvement = Player.GetComponent<PlayerMouvement>();
        }

        vitesseActuel = playerMouvement.speedMultiplier;
        Vector3 objectScale = Player.transform.localScale;
        Player.transform.localScale = new Vector3(objectScale.x, objectScale.y / 10, objectScale.z);
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Temps >= TempsquiAvance)
        {
            playerMouvement.speedMultiplier = Mathf.Lerp(vitesseActuel, 0.3f, TempsquiAvance / Temps);
            TempsquiAvance += Time.deltaTime;
        }
        else
        {
            animator.SetBool("isSliding", false);
            animator.SetBool("isCrouching", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!animator.GetBool("isCrouching"))
        {
            playerMouvement.speedMultiplier = 1f;
            Player.transform.localScale = new Vector3(1, 1, 1);
        }
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
