using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMouvement))]
public class CharacterSound : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Event Steps;
    public AK.Wwise.Event LaneSwitch;
    [SerializeField] private AK.Wwise.Event Jump_Start;
    [SerializeField] private AK.Wwise.Event Jump_End;
    [SerializeField] private AK.Wwise.Event Dash;
    public AK.Wwise.RTPC Speed;

    private PlayerMouvement Player;

    public bool inAir;

    private void Start()
    {
        if(Player == null) Player = GetComponent<PlayerMouvement>();
    }

    private void Update()
    {
        //Speed.SetGlobalValue();

        if (!Player.characterController.isGrounded && !inAir)
        {
            inAir = true;
        }
        else if (inAir && Player.characterController.isGrounded)
        {
            inAir = false;
            Jump(inAir);
        }

        if(Input.GetButtonDown("Jump")) Jump(true);        

    }

    public void Step()
    {
        if(Player.characterController.isGrounded && !Player.StateMachine.GetBool("isSliding")) Steps.Post(gameObject);
    }

    public void DashSound()
    {
        Dash.Post(gameObject);
    }

    public void Jump(bool Start)
    {
        if (Start)
        {
            Jump_Start.Post(gameObject);
        }
        else
        {
            Jump_End.Post(gameObject);
        }
    }
}
