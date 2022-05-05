using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectils_Shooter : MonoBehaviour
{
    [SerializeField] private GameObject Projectil;
    [SerializeField] private Transform SpawnPoint;
    [SerializeField] private bool AutoShoot;

    [SerializeField] private float Cooldown;
    private float Timer;

    [SerializeField] private bool IsOffset;
    [SerializeField] [Range(0,100)] private float Offset;

    [Header("on Sync")]
    [SerializeField] [Range(1, 8)] private int BeatLenght;
    public int BeatCount = 0;

    [SerializeField] [Range(0, 8)] private int OffsetLenght;
    public int OffsetCount = 0;

    public bool HalfBeat;

    private void Start()
    {
        if (IsOffset)
        {
            Timer += Cooldown * (Offset / 100);
        }

        if(HalfBeat) Music_Manager.OnHalfBeat += onBeat;
        else Music_Manager.OnBeat += onBeat;
    }

    private void OnDestroy()
    {
        if (HalfBeat) Music_Manager.OnHalfBeat -= onBeat;
        else Music_Manager.OnBeat -= onBeat;
    }

    private void Update()
    {
        if (AutoShoot)
        {
            if(Timer <= Time.time - Cooldown)
            {
                Shoot();
                Timer = Time.time;
            }
        }
    }

    void onBeat()
    {
        if (!AutoShoot)
        {
            if (OffsetCount < OffsetLenght)
            {
                OffsetCount++;
                return;
            }

            if (BeatCount >= BeatLenght)
            {
                Shoot();
                BeatCount = 1;
            }
            else
            {
                BeatCount++;
            }
        }
    }

    void Shoot()
    {
        if (!Input.GetButton("Fire2"))
        {
            if (SpawnPoint) Instantiate(Projectil, SpawnPoint.position, SpawnPoint.rotation);
            else Instantiate(Projectil, transform.position, transform.rotation);
        }
    }
}