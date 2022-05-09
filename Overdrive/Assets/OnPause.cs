using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPause : MonoBehaviour
{
    public GameManager Manager;

    // Update is called once per frame
    public void OnClick()
    {
        Manager.PauseGame();
    }
}
