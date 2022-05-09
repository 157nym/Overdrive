using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpSound : MonoBehaviour
{
    public AK.Wwise.Event PopUp;
    public AK.Wwise.Event Click;

    void Start()
    {
        PopUp.Post(gameObject);
    }

    public void close()
    {
        Click.Post(gameObject);
    }
}
