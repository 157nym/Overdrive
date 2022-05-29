using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Spinner_PopUp : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Transform Handle;
    private RectTransform HandleRect;
    Vector3 cursorPos;
    private bool Dragged;
    public float TargetAngle;
    private Image Image;

    public float angle;

    [Range(0,360)]public float Offset;

    public int NbTour;
    public int NeededTour;
    public float Speed;

    public AK.Wwise.Event PopUp;

    public GameObject parent;

    public Color StartColor;
    public Color FinishColor;

    private void Start()
    {
        Handle = GetComponent<Transform>();
        HandleRect = GetComponent<RectTransform>();
        Image = GetComponent<Image>();
        PopUp.Post(gameObject); 
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Dragged = true;

        cursorPos = Input.mousePosition;
        Vector2 dir = cursorPos - Handle.position;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angle = (angle <= 0) ? (angle + 360) : angle;


        Quaternion newRot = Quaternion.AngleAxis(angle + Offset, Vector3.forward);
        Handle.rotation = newRot;

        TargetAngle = Handle.rotation.z + .5f;
        if (TargetAngle > 1) TargetAngle -= 2;
    }

    public void OnDrag(PointerEventData eventData)
    {
        cursorPos = Input.mousePosition;
        Vector2 dir = cursorPos - Handle.position;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angle = (angle <= 0) ? (angle + 360) : angle;


        Quaternion newRot = Quaternion.AngleAxis(angle + Offset, Vector3.forward);
        Handle.rotation = newRot;


        if (-0.05f <= HandleRect.rotation.z - TargetAngle && HandleRect.rotation.z - TargetAngle <= 0.05f)
        {
            NbTour++;
            TargetAngle += .5f;
            if (TargetAngle > 1) TargetAngle -= 2;
        }

        if (NeededTour <= NbTour && Dragged)
        {
            Destroy(parent);
        }
        float t = (float)NbTour / (float)NeededTour;
        Image.color = Color.Lerp(StartColor, FinishColor, t);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Dragged = false;
        angle = (angle <= 0) ? (angle + 360) : angle;
        angle += Offset;
        NbTour = 0;
        Image.color = StartColor;
    }

    private void Update()
    {

        if (!Dragged)
        {
            angle = Mathf.Lerp(angle, (angle > 180) ? 360 : 0, Speed * Time.deltaTime);
            Quaternion newRot = Quaternion.AngleAxis(angle, Vector3.forward);
            Handle.rotation = newRot;
        }

    }
}
