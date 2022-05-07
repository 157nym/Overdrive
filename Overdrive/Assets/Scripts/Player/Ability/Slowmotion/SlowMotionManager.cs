using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotionManager : MonoBehaviour
{
    public float slowdownFactor = 0.05f;
    public float slowdownLenght = 2f;
    public bool Slow = false;

    
    void Update()
    {
        //Time.timeScale += (1f / slowdownLenght) * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.A))
        {
            SlowMotion();
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            NormalMotion();
        }
    }
    void SlowMotion()
    {
        Slow = true;
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.unscaledDeltaTime * 0.2f;
    }
    
    void NormalMotion()
    {
        Slow = false;
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.unscaledDeltaTime * 0.2f;
    }
}
