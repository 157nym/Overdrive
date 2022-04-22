using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovementAutoRun))]
public class CharacterSound : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Event Steps;
    [SerializeField] private AK.Wwise.Event Jump_Start;
    [SerializeField] private AK.Wwise.Event Jump_End;
    [SerializeField] private AK.Wwise.Event Slide;
    public AK.Wwise.RTPC Speed;

    private PlayerMouvement Player;

    bool jumping = false;

    private void Start()
    {
        if(Player == null) Player = GetComponent<PlayerMouvement>();
    }

    public void Step()
    {
        Steps.Post(gameObject);
    }

    public void slide()
    {
        Slide.Post(gameObject);
    }

    public void Jump()
    {
        if (!jumping)
        {
            Jump_Start.Post(gameObject);
            jumping = true;
        }
    }

    void BackRunning()
    {
        if (jumping)
        {
            Jump_End.Post(gameObject);
            jumping = false;
        }
    }
}
