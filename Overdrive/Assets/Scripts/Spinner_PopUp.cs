using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Spinner_PopUp : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Transform Handle;
    Vector3 cursorPos;
    private bool Dragged;
    private float StartAngle;

    public float angle;

    [Range(0,360)]public float Offset;

    public int NbTour;
    public int NeededTour;
    public float Speed;

    public AK.Wwise.Event PopUp;

    public GameObject parent;

    private void Start()
    {
        Handle = GetComponent<Transform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Dragged = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        cursorPos = Input.mousePosition;
        Vector2 dir = cursorPos - Handle.position;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if (angle <= 0)
        {
            NbTour++;
        }

        angle = (angle <= 0) ? (angle + 360) : angle;
        Quaternion newRot = Quaternion.AngleAxis(angle + Offset, Vector3.forward);
        Handle.rotation = newRot;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Dragged = false;
        angle = (angle <= 0) ? (angle + 360) : angle;
        angle += Offset;
        NbTour = 0;
    }

    private void Update()
    {
        if(NeededTour <= NbTour && Dragged)
        {
            Destroy(parent);
        }

        if (!Dragged)
        {
            angle = Mathf.Lerp(angle, (angle > 180) ? 360 : 0, Speed * Time.deltaTime);
            Quaternion newRot = Quaternion.AngleAxis(angle, Vector3.forward);
            Handle.rotation = newRot;
        }
    }
}
