using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp_Slider : MonoBehaviour
{
    private Slider slider;
    private bool selected;

    public float speed;

    public GameObject Parent;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    private void Update()
    {
        if (slider.value == 1)
            Destroy(Parent);
        if (!selected && slider.value != 0)
        {
            slider.value = Mathf.Lerp(slider.value, 0, speed * Time.deltaTime);
            Debug.Log("slide"); 
        }
    }

    public void onSelected()
    {
        selected = true;
    }
    public void onUnSelected()
    {
        selected = false;
    }

}
