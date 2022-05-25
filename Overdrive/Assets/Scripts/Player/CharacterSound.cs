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
    [SerializeField] private AK.Wwise.Event Death;
    [SerializeField] private AK.Wwise.Event Pause;
    [SerializeField] private AK.Wwise.Event Resume;
    public AK.Wwise.State sliding;
    public AK.Wwise.State running;
    public AK.Wwise.State Jumping;
    public AK.Wwise.State Dead;
    public AK.Wwise.State Alive;
    public AK.Wwise.RTPC Speed;
    [SerializeField] private AK.Wwise.Event Music;

    private void Awake()
    {
        player = GetComponent<CharacterMovementAutoRun>();
        Slide.Post(gameObject);
        running.SetValue();
        Alive.SetValue();
    }

    public void CountDown()
    {
        Countdown.Post(gameObject);
    }

    private void OnDestroy()
    {
        Music.Stop(gameObject);
    }

    public void Glitch()
    {
        Death.Post(gameObject);
        Dead.SetValue();
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

    public void PauseGame()
    {
        Pause.Post(gameObject);
    }

    public void ResumeGame()
    {
        Resume.Post(gameObject);
    }
}
