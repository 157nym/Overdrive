using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragDrop : EventTrigger
{
    [SerializeField]
    private Canvas canvas;

    private bool startDragging;

    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
    }

    void Update()
    {
        if (startDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

    // Update is called once per frame
    public override void OnPointerDown(PointerEventData eventData)
    {
        startDragging = true;
    }
    
    public override void OnPointerUp(PointerEventData eventData)
    {
        startDragging = false;
    }
}
