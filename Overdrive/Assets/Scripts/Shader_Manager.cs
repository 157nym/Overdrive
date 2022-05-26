using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Shader_Manager : MonoBehaviour
{
    public float Dither_Length;
    public float Dither_Distance;

    void Update()
    {
        Shader.SetGlobalFloat("DitherLenght", Dither_Length);
        Shader.SetGlobalFloat("DitherPosition", Dither_Distance);
    }
}
