using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life_Hud : MonoBehaviour
{
    public int Life = 4;

    public Sprite[] Life_Tex;

    public Image bar;
    private Animator anim;

    private void Start()
    {
        bar.sprite = Life_Tex[Life - 1];
        anim = GetComponent<Animator>();
    }

    public void Damage()
    {
        Life--;
        if(Life > 0)  bar.sprite = Life_Tex[Life - 1];
        anim.SetTrigger("Damage");
    }
}