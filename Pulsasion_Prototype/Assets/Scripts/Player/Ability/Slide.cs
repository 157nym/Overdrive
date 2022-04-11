using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Slide : MonoBehaviour
{
    public float DefaultSpeed;
    public float SlideSpeed;
    public float SlideDuration;

    public float DefaultPlayerSpeed;
    public bool IsSliding;
    [SerializeField] private bool CanStand;

    public PlayerMouvement Player;

    void Start()
    {
        IsSliding = false;
        Player = gameObject.GetComponent<PlayerMouvement>();
    }


    void Update()
    {
        if (IsSliding == true && SlideSpeed > 0)
            SlideSpeed = SlideSpeed - (SlideSpeed / SlideDuration) * Time.unscaledDeltaTime;

        if (IsSliding == false)
            SlideSpeed = DefaultSpeed;


        if (Input.GetKeyDown("left ctrl"))
        {
            slide();
        }

        if (Input.GetKey("left ctrl") && Player.runningSpeed > 0.2)
        {
            Player.runningSpeed = DefaultPlayerSpeed * SlideSpeed;
        }
        else if (Physics.Raycast(transform.position, transform.up, 2))
        {
            Debug.Log("can't stand");
            return;
        }
        else if (IsSliding)
        {
            Stand();
        }
    }


    void slide()
    {
        Vector3 objectScale = transform.localScale;
        transform.localScale = new Vector3(objectScale.x, objectScale.y / 10, objectScale.z);
        IsSliding = true;
        DefaultPlayerSpeed = Player.runningSpeed;
    }

    void Stand()
    {
        Vector3 objectScale = transform.localScale;
        transform.localScale = new Vector3(objectScale.x, objectScale.y * 10, objectScale.z);
        IsSliding = false;
        Player.runningSpeed = DefaultPlayerSpeed;
    }
}