using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class CharacterMovementAutoRun : MonoBehaviour
{
    private ParticleSystem SpeedEffect;
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;

    public CharacterSound sound;

    private int desireLane = 1;
    public float laneDistance = 4f;
    public float gravity = -20;
    public float DuréeAnim;
    public float speedAugmentation;
    public float speedMax;

    public int NbrPop;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        sound = GetComponent<CharacterSound>();
        SpeedEffect = Camera.main.GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        SpeedEffect.emissionRate = forwardSpeed;

        if(NbrPop >= 10)
        {
            SceneManager.LoadScene("Auto_Runner_Lvl");
        }

        if (forwardSpeed < speedMax)
        {
            forwardSpeed += speedAugmentation * 10 * Time.deltaTime;
            DuréeAnim = (forwardSpeed*4)/40;
            animator.SetFloat("AnimSpeed", DuréeAnim);
            sound.Speed.SetGlobalValue(DuréeAnim/2);
        }
        
        direction.z = forwardSpeed;


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desireLane++;
            if (desireLane == 3)
            {
                desireLane = 2;
            }
            else
            {
                sound.LaneSwitch.Post(gameObject);
            }
        }


        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desireLane--;
            if (desireLane == -1)
            {
                desireLane = 0;
            }
            else
            {
                sound.LaneSwitch.Post(gameObject);
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Slide();
        }
        
        if(controller.isGrounded)
        {

            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                StartCoroutine(Jump(1f));
            }


            if (SwipeManager.swipeUp)
            {
                if (EventSystem.current.IsPointerOverGameObject())
                    return;
                StartCoroutine(Jump(1f));
            }
        }
        else
        {
            direction.y += gravity * Time.deltaTime;
        }


        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (SwipeManager.swipeDown)
            {
                Slide();
            }

            if (SwipeManager.swipeRight)
            {
                desireLane++;
                if (desireLane == 3)
                {
                    desireLane = 2;
                }
                else
                {
                    sound.LaneSwitch.Post(gameObject);
                }
            }

            if (SwipeManager.swipeLeft)
            {
                desireLane--;
                if (desireLane == -1)
                {
                    desireLane = 0;
                }
                else
                {
                    sound.LaneSwitch.Post(gameObject);
                }
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

        transform.position = Vector3.Lerp(transform.position,targetPosition, 20 * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }

    IEnumerator Jump(float JumpReset)
    {
        Debug.Log("Jumping");
        animator.SetTrigger("Jumping");
        yield return new WaitForSeconds(JumpReset);
        animator.ResetTrigger("Jumping");
    }

    private void Slide()
    {
        animator.SetTrigger("Sliding");
    }
}
