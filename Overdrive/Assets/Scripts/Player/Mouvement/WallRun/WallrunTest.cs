using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallrunTest : MonoBehaviour
{
public Transform playerPosition;
//controls the x movement. (right/left)
public float horizontalmove;
//controls the y movement. (forward/back)
public float verticalmove;
//controls the movement direction.
private Vector3 playerInput;
//Here I store my character controller.
public CharacterController player;
//controls the player speed.
public float playerSpeed;
//controls de movement direction according to camera 
public Vector3 movePlayer;
//controls the last movement
public Vector3 lastMovePlayer;

public float gravity = 9.8f;
public float fallVelocity;
public float jumpForce = 5.0f;
public float verticalSpeed;

private RaycastHit HitR;
private RaycastHit HitL;

//Here I store the main camera
public Camera mainCamera;
//It stores the camera direction when the player is looking forward.
private Vector3 camForward;
//It stores the camera direction when the player is looking right.
private Vector3 camRight;

//Checks
//The meaning of Caida is fall.
public bool Caida;
//The meaning of salto is jump.
public bool Salto;
public bool Wallrun;
public bool WallrunCount;

// Start is called befoe the first frame update
void Start()
{
    //i store the character controler.
    player = GetComponent<CharacterController>();

    Caida = true;
}

// Update is called once per frame
void Update()
{
    if (Wallrun == true)
    {
        Caida = false;
    }
    if (Salto == true)
    {
        fallVelocity -= gravity * Time.deltaTime;
        movePlayer = lastMovePlayer;
    }
    if (Caida == true)
    {
        fallVelocity -= gravity * Time.deltaTime;
    }
    if (player.isGrounded && Wallrun == false)
    {
        Caida = false;
        Salto = false;
        WallrunCount = false;
        //I assign the horizontal move to the w and s keys.
        horizontalmove = Input.GetAxis("Horizontal");

        //I assign the vertical move to the a and d keys.)
        verticalmove = Input.GetAxis("Vertical");

        //controls the movement direction
        playerInput = new Vector3(horizontalmove, 0, verticalmove);

        //limits the player speed. With this method if teh player waalks in diagonal doesn´t 
        //exceed the speed limit.
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        // It calls the function that give the camera look direction.
        camDirection();

        //Here, It`s calculates the player movement considering the camera point and the movement 
        //we have assing to teh player earlier
        //With this method the player always moves looking to the camera
        movePlayer = playerInput.x * camRight + playerInput.z * camForward;

        //The movement * the speed we want.
        movePlayer = movePlayer * playerSpeed;

        //we are going to say to the player where is looking at.
        player.transform.LookAt(player.transform.position + movePlayer);

        //It gives the gravity to the player.
        fallVelocity = -gravity * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Salto = true;
            fallVelocity = jumpForce;
        }
    }
    else if (!player.isGrounded && Salto == false && Wallrun == false)
    {
        Caida = true;
    }

    movePlayer.y = fallVelocity;

    //we give the movement to th eplayer.
    player.Move(movePlayer * Time.deltaTime);
    lastMovePlayer = movePlayer;
}

private void OnTriggerStay(Collider other)
{
    if (Input.GetKeyDown(KeyCode.LeftShift) && Wallrun == false && WallrunCount == false)
    {
        if (Input.GetKey("z"))
        {
            Wallrun = true;
            WallrunCount = true;
            fallVelocity = 5f;
            movePlayer.y = fallVelocity;
            movePlayer.z = movePlayer.z * 1.6f;
            if (Physics.Raycast(transform.position, transform.right, out HitR, 1))
            {
                movePlayer.x = 1.6f;
            }
            else if (Physics.Raycast(transform.position, -transform.right, out HitL, 1))
            {
                movePlayer.x = -1.6f;
            }
            StartCoroutine(wallrunTime());
        }
    }
}

void camDirection()
{
    //we store the forward and right directions here.
    camForward = mainCamera.transform.forward;
    camRight = mainCamera.transform.right;

    //we block the direction and the camera direction because we are not going to use it.
    camForward.y = 0;
    camRight.y = 0;

    //It gives as the normalized vectors.
    camForward = camForward.normalized;
    camRight = camRight.normalized;

}

private void OnControllerColliderHit(ControllerColliderHit hit)
{
    if (!player.isGrounded && hit.normal.y < 0.1f)
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            fallVelocity = jumpForce;
            movePlayer = hit.normal * 7;
            player.transform.LookAt(player.transform.position + movePlayer);
        }
    }
}

IEnumerator wallrunTime()
{
    yield return new WaitForSeconds(1);
    Wallrun = false;
}
}
