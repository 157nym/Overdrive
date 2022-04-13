using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBeat_Action : MonoBehaviour
{
    private Animator Anim;
    [Range(1,8)] public int BeatLenght;
    public int BeatCount = 0;

    [SerializeField] [Range(0, 8)] private int OffsetLenght;
    public int OffsetCount = 0;

    public bool HalfBeat;

    void Start()
    {
        Anim = GetComponent<Animator>();

        if (HalfBeat) Music_Manager.OnHalfBeat += onBeat;
        else Music_Manager.OnBeat += onBeat;

        Anim.SetFloat("Speed", Music_Manager.Tempo / 60);
    }

    private void OnDestroy()
    {
        if (HalfBeat) Music_Manager.OnHalfBeat -= onBeat;
        else Music_Manager.OnBeat -= onBeat;
    }

    void onBeat()
    {
        if (OffsetCount < OffsetLenght)
        {
            OffsetCount++;
            return;
        }

        if (BeatCount >= BeatLenght)
        {
            if (!Input.GetButton("Fire2"))
            {
                Animate();
            }
            BeatCount = 1;
        }
        else
        {
            BeatCount++;
        }
    }

    void Animate()
    {
        Anim.SetTrigger("Beat");
    }
}
