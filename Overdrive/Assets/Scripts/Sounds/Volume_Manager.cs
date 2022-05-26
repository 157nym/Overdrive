using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume_Manager : MonoBehaviour
{
    public AK.Wwise.RTPC Main_Volume;
    public AK.Wwise.RTPC Music_Volume;
    public AK.Wwise.RTPC SFX_Volume;

    public float main_volume;
    public float music_volume;
    public float sfx_volume;

    public void Set_Main_Volume(Slider volume)
    {
        main_volume = volume.value;
        Main_Volume.SetGlobalValue(main_volume);
    }

    public void Set_Music_Volume(Slider volume)
    {
        music_volume = volume.value;
        Music_Volume.SetGlobalValue(music_volume);
    }

    public void Set_SFX_Volume(Slider volume)
    {
        sfx_volume = volume.value;
        SFX_Volume.SetGlobalValue(sfx_volume);
    }

    private void Update()
    {
        if (main_volume != Main_Volume.GetValue(gameObject))
        {
            Main_Volume.SetGlobalValue(main_volume);
        }

        if (music_volume != Music_Volume.GetValue(gameObject))
        {
            Music_Volume.SetGlobalValue(music_volume);
        }

        if (sfx_volume != SFX_Volume.GetValue(gameObject))
        {
            SFX_Volume.SetGlobalValue(sfx_volume);
        }
    }
}