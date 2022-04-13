using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Music_Manager : MonoBehaviour
{
    public static event Action OnBeat;
    public static event Action OnHalfBeat;

    [SerializeField] private AK.Wwise.Switch Music;

    [SerializeField] private AK.Wwise.Event MusicEvent;

    [SerializeField] private AK.Wwise.RTPC Speed_Modifier;

    [SerializeField] public static float Tempo;

    private void Start()
    {
        MusicEvent.Post(gameObject, (uint)AkCallbackType.AK_MusicSyncAll, CallbackFunction);
    }

    private void OnDestroy()
    {
        MusicEvent.Stop(gameObject);
    }

    void CallbackFunction(object in_cookie, AkCallbackType in_type, object in_info)
    {
        if (in_type == AkCallbackType.AK_MusicSyncBeat) beatEvent();
        if (in_type == AkCallbackType.AK_MusicSyncGrid) HalfbeatEvent();

        AkMusicSyncCallbackInfo info = (AkMusicSyncCallbackInfo)in_info;
        Tempo = 60 / info.segmentInfo_fBeatDuration;
    }

    

    private void Update()
    {
        Music.SetValue(gameObject);
        Speed_Modifier.SetGlobalValue(Time.timeScale);
    }

    public void beatEvent()
    {
        OnBeat?.Invoke();
    }

    public void HalfbeatEvent()
    {
        OnHalfBeat?.Invoke();
    }
}
