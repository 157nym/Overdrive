using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool AutoMove;

    [SerializeField] private float Cooldown;
    private float Timer;

    [SerializeField] private bool IsOffset;
    [SerializeField] [Range(0, 100)] private float Offset;

    bool isUp;
    [SerializeField] private bool isAPlatform;
    [SerializeField] private Transform EndPos;
    private Vector3 Pos;
    private BoxCollider Trigger;

    private void Start()
    {
        Trigger = gameObject.AddComponent<BoxCollider>();
        Trigger.size = new Vector3(1, .7f, 1);
        Trigger.center = new Vector3(0, 0.5f, 0);
        Trigger.isTrigger = true;

        Pos = transform.position;

        if (IsOffset)
        {
            Timer += Cooldown * (Offset / 100);
        }
    }

    private void Update()
    {
        if (AutoMove)
        {
            if (Timer <= Time.time - Cooldown)
            {
                Move();
                Timer = Time.time;
            }
        }
    }

    void Move()
    {
        if (isUp) LeanTween.move(gameObject, EndPos.position, speed).setEaseInOutSine();
        else LeanTween.move(gameObject, Pos, speed).setEaseInOutSine();
        isUp = !isUp;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isAPlatform)
        {
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isAPlatform)
        {
            other.transform.parent = null;
        }
    }
    void OnDrawGizmosSelected()
    {
        // Draw a semitransparent blue cube at the transforms position
        Gizmos.color = new Color(0, 0, 1, 0.5f);
        Gizmos.DrawCube(EndPos.position, new Vector3(2, 2, 2));
    }
}
