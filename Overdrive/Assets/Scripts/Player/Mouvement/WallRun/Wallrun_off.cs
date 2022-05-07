using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallrun_off : MonoBehaviour
{
    // Start is called before the first frame update
    //public PlayerMovement playerparametre;
    public bool IsJump;
    private bool isWallRun;
    public bool Right, Left;
    private bool WallLeft, WallRight;
    public float gravityWallRun;
    public LayerMask WallForRun;
    public float timeray;


    void Start()
    {

        Right = false;
        Left = false;
        WallLeft = false;
        WallRight = false;

        

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(IsJump);
        WallDetection();
        WallSide();

    }

    void WallSide()
    {
        if (IsJump == true && Left == true)
        {
            Debug.Log("le mur gauche est d�t�ct�");
            WallLeft = true;
            

        }

        if (IsJump == true && Right == true)
        {
            Debug.Log("le mur droite est d�t�ct�");
            WallRight = true;
            

        }

        

    }
    void WallRun()
    {

    }

    void WallDetection()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.right, out hit, 2f, WallForRun))
        {
            Debug.DrawRay(transform.position, -transform.right * hit.distance, Color.yellow);
            Debug.DrawLine(transform.position, hit.point);
            //Debug.Log("Gauche");
            Left = true;


        }
        else if (Physics.Raycast(transform.position, transform.right, out hit, 2f, WallForRun))
        {
            Debug.DrawRay(transform.position, transform.right * hit.distance, Color.yellow);
            Debug.DrawLine(transform.position, hit.point);
            //Debug.Log("Droite");
            Right = true;

        }
        else
        {
            Left = false;
            Right = false;
        }
    }
}
