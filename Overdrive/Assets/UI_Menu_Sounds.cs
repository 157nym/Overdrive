using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Menu_Sounds : MonoBehaviour
{
    public AK.Wwise.Event DecoSound;
    public AK.Wwise.Event StartMenu;
    public AK.Wwise.Event StartGame;

    public bool isDecoSound = false;

    public void PlayDecoSound()
    {
        DecoSound.Post(gameObject);
    }
    
    public void PlayStartMenu()
    {
        StartMenu.Post(gameObject);
        isDecoSound = true;
    }

    public void PlayStartGame()
    {
        StartGame.Post(gameObject);
        isDecoSound = false;
    }

    //play deco sound at randome time interval
    public void PlayDecoSoundRandom()
    {
        if (isDecoSound)
        {
            StartCoroutine(PlayDecoSoundRandomIE());
        }
        else
        {
            PlayDecoSound();
        }
    }

    IEnumerator PlayDecoSoundRandomIE()
    {
        yield return new WaitForSeconds(Random.Range(10, 30));
        PlayDecoSound();
        PlayDecoSoundRandom();
    }
}
