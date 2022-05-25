using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovementAutoRun))]
public class CharacterSound : MonoBehaviour
{
    private CharacterMovementAutoRun player;
    [SerializeField] private AK.Wwise.Event Steps;
    public AK.Wwise.Event LaneSwitch;
    [SerializeField] private AK.Wwise.Event Jump_Start;
    [SerializeField] private AK.Wwise.Event Jump_End;
    [SerializeField] private AK.Wwise.Event Slide;
    [SerializeField] private AK.Wwise.Event Countdown;
    public AK.Wwise.State sliding;
    public AK.Wwise.State running;
    public AK.Wwise.State Jumping;
    public AK.Wwise.RTPC Speed;
    [SerializeField] private AK.Wwise.Event Music;

    private void Awake()
    {
        player = GetComponent<CharacterMovementAutoRun>();
        Slide.Post(gameObject);
        running.SetValue();
    }

    public void CountDown()
    {
        Countdown.Post(gameObject);
    }

    private void OnDestroy()
    {
        Music.Stop(gameObject);
    }

    public void MusicStart()
    {
        Music.Post(gameObject);
    }

    public void Step()
    {
        if(player.forwardSpeed > 5) Steps.Post(gameObject);
    }

    public void Sliding()
    {
        sliding.SetValue();
    }

    public void Jump()
    {
        Jumping.SetValue();
        Jump_Start.Post(gameObject);
    }
    public void Jump_land()
    {
        Jump_End.Post(gameObject);
    }

    void Running()
    {
        running.SetValue();
    }
}
