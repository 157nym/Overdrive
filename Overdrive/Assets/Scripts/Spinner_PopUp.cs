using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[ExecuteInEditMode]
public class Spinner_PopUp : MonoBehaviour
{
    public AK.Wwise.Event PopUp;
    public AK.Wwise.Event Click;

    public GameObject Parent;

    [Header("Filler")]

    public GameObject Filler;
    [Range(0, 100)] public float Fill;
    public float FillTime;

    public Color StartColor;
    public Color EndColor;

    private bool isDragging;

    private void Start()
    {
        PopUp.Post(gameObject); 
    }

    public void StartDrag()
    {
        isDragging = true;
    }

    public void EndDrag()
    {
        isDragging = false;
    }

    private void Update()
    {
        //empty fill if not dragging
        if (!isDragging && Fill > 0)
        {
            Fill -= (500 / FillTime) * Time.deltaTime;
        }
        else
        {
            Fill = Mathf.Clamp(Fill, 0, 100);
        }

        if (isDragging)
        {
            //fill fill in filltime
            Fill += (100 / FillTime) * Time.deltaTime;
        }

        if (Fill >= 100)
        {
            Destroy(Parent);
        }

        //filler size from fill
        Filler.GetComponent<RectTransform>().localScale = new Vector3(Fill / 100, Fill / 100, 1);

        //lerp Color from size
        Filler.GetComponent<Image>().color = Color.Lerp(StartColor, EndColor, Fill / 100);
    }

    private void OnDestroy()
    {
        Click.Post(gameObject);
    }
}