using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideBox : MonoBehaviour
{
    public Canvas mainCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 c1 = mainCanvas.worldCamera.ScreenToWorldPoint(Vector3.zero);
        Vector3 c2 = mainCanvas.worldCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
 
        Rect canvasRect = new Rect( c1, new Vector2(c2.x-c1.x, c2.y-c1.y));  

        Vector3[] corners = new Vector3[4];
 
        GetComponent<RectTransform>().GetWorldCorners(corners);
 
        Rect rec = new Rect(corners[0].x, corners[0].y, corners[2].x-corners[0].x, corners[2].y-corners[0].y);
 
        if (!rec.Overlaps(canvasRect))
        {
            Destroy(gameObject);
        }
    }
}
