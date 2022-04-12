using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementAutoRun : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;

    private int desireLane = 1;
    public float laneDistance = 4f;
    public float jumpForce;
    public float gravity = -20;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = forwardSpeed;

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartCoroutine(Slide());
        }
        if(controller.isGrounded)
        {
            //direction.y = -1f;
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
        }
        else
        {
            direction.y += gravity * Time.deltaTime;
            animator.SetBool("IsJumping", false);
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            desireLane ++;
            if(desireLane == 3)
            {
                    desireLane =2;    
            }
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desireLane --;
            if(desireLane == -1)
            {
                    desireLane =0;    
            }
        }


        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(desireLane ==0)
        {
            targetPosition += Vector3.left * laneDistance;
        }

        else if(desireLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        transform.position = Vector3.Lerp(transform.position,targetPosition, 50 * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        direction.y = jumpForce;
        animator.SetBool("IsJumping", true);
    }

    private IEnumerator Slide()
    {
        animator.SetBool("IsSliding", true);

        yield return new WaitForSeconds(0.8f);
        
        animator.SetBool("IsSliding", false);
    }
}
