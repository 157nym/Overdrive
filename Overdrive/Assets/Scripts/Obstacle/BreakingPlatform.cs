using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingPlatform : MonoBehaviour
{
    public bool isPlayerOnPlatform;
    public bool isActive, isChanging;

    [SerializeField] private float Cooldown;
    public float Timer;

    MeshRenderer Mesh;
    Collider Col;

    BoxCollider Trigger;

    [SerializeField] private Color WarningColor;
    private Color BaseColor;

    private void Start()
    {
        Trigger = gameObject.AddComponent<BoxCollider>();
        Trigger.size = new Vector3(1, .7f, 1);
        Trigger.center = new Vector3(0, 0.5f, 0);
        Trigger.isTrigger = true;

        Mesh = GetComponent<MeshRenderer>();
        BaseColor = Mesh.material.color;

        Col = GetComponent<Collider>();
    }

    private void Update()
    {
        if (isChanging && isActive)
        {
            if (Timer <= Time.time - Cooldown)
            {
                ToggleActive(false);
            }
        }
        else if (!isPlayerOnPlatform)
        {
            if (Timer <= Time.time - Cooldown)
            {
                ToggleActive(true);
            }
        }

        if(isPlayerOnPlatform && !isActive)
        {
            Timer = Time.time;
        }

        if (isChanging)
        {
            Mesh.material.color = Color.Lerp(Mesh.material.color, WarningColor, Time.deltaTime/Cooldown);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Timer = Time.time;
            isPlayerOnPlatform = true;
            isChanging = true;

            //LeanTween.color(gameObject, WarningColor, Cooldown).setEaseInSine();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Timer = Time.time;
            isPlayerOnPlatform = false;

            //LeanTween.color(gameObject, BaseColor, Cooldown).setEaseInSine();
        }
    }

    void ToggleActive(bool state)
    {
        Mesh.enabled = state;
        Col.isTrigger = !state;
        isActive = state;

        Timer = Time.time;

        isChanging = false;

        if (state)
        {
            Mesh.material.color = BaseColor;
        }
    }
}
