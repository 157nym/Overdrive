using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume_Manager : MonoBehaviour
{
    public AK.Wwise.RTPC Main_Volume;
    public AK.Wwise.RTPC Music_Volume;
    public AK.Wwise.RTPC SFX_Volume;

    public float main_volume;
    public float music_volume;
    public float sfx_volume;

    public void Set_Main_Volume(float volume)
    {
        main_volume = volume;
        Main_Volume.SetValue(gameObject, main_volume);
    }

    public void Set_Music_Volume(float volume)
    {
        music_volume = volume;
        Music_Volume.SetValue(gameObject, music_volume);
    }

    public void Set_SFX_Volume(float volume)
    {
        sfx_volume = volume;
        SFX_Volume.SetValue(gameObject, sfx_volume);
    }

    private void Update()
    {
        if (main_volume != Main_Volume.GetValue(gameObject))
        {
            Set_Main_Volume(main_volume);
        }

        if (music_volume != Music_Volume.GetValue(gameObject))
        {
            Set_Music_Volume(music_volume);
        }

        if (sfx_volume != SFX_Volume.GetValue(gameObject))
        {
            Set_SFX_Volume(sfx_volume);
        }
    }
}