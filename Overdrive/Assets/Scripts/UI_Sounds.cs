using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Sounds : MonoBehaviour
{
    public AK.Wwise.Event Click;

    public void Clik()
    {
        Click.Post(gameObject);
    }
}
