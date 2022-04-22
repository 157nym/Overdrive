using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideBox : MonoBehaviour
{
    public Canvas canvas;

    private RectTransform MyRect;

    public float MaxPosY,MaxPosX,MinPosY,MinPosX;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
        MyRect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 c1 = Camera.main.ScreenToWorldPoint(Vector3.zero);
        Vector3 c2 = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        
        Rect canvasRect = new Rect( c1, new Vector2(c2.x-c1.x, c2.y-c1.y));  
        
        Vector3[] corners = new Vector3[4];
        
        GetComponent<RectTransform>().GetWorldCorners(corners);
        
        Rect rec = new Rect(corners[0].x, corners[0].y, corners[3].x-corners[0].x, corners[3].y-corners[0].y);

        if (rec.Overlaps(canvasRect))
        {
            Debug.Log("destroy");
            Destroy(gameObject);
        }
    }
}
