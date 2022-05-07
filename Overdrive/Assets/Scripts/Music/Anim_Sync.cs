using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Anim_Sync : MonoBehaviour
{
    public bool SpeedOnBeatLenght;

    private Animator Anim;
    private OnBeat_Action Beat;

    void Start()
    {
        Anim = GetComponent<Animator>();
        Beat = GetComponent<OnBeat_Action>();
    }

    void Update()
    {
        if (SpeedOnBeatLenght)
        {
            Anim.SetFloat("Speed", ((Music_Manager.Tempo / 60)/Beat.BeatLenght));
        }
        else
        {
            Anim.SetFloat("Speed", (Music_Manager.Tempo / 60));
        }

        if (Beat.HalfBeat) Anim.SetFloat("Speed", Anim.GetFloat("Speed") * 2);

        if (Input.GetButton("Fire2"))
        {
            Anim.SetFloat("Speed", 0);
        }
    }
}
