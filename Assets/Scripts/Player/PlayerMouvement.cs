using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class PlayerMouvement : MonoBehaviour
{
    //Camera
    public Camera playerCamera;

    public Animator StateMachine;

    //Composant qui permet de faire bouger le joueur
    public CharacterController characterController;

    public bool isDashing;

    //Vitesse de course
    public float runningSpeed = 15f;

    public float speedZ = 1;

    //Gravité
    public float gravity = 20f;

    //Déplacement
    Vector3 moveDirection;

    //Marche ou court ?
    private bool isRunning = false;

    //Rotation de la caméra
    float rotationX = 0;
    public float rotationSpeed = 2.0f;
    public float rotationXLimit = 45.0f;
    
    //Pour le Dash
    public float DashSpeed;
    public float DashTime;

    float StartTime;
    private Transform Cam;
    
    [SerializeField] private float CoolDown = 0;
    [SerializeField] public bool CoolDownOK;

    public float Velocity;
    public float speedMultiplier = 1;

    [SerializeField] private ParticleSystem TWODNUTS;
    [SerializeField] private int MinFOV;
    [SerializeField] private int MaxFOV;

    public float runTime = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        //Cache le curseur de la souris
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        characterController = GetComponent<CharacterController>();

        playerCamera = Camera.main;

        StartTime = -1f;
        Cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Calcule les directions
        //forward = avant/arrière
        //right = droite/gauche
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        //Est-ce qu'on appuie sur un bouton de direction ?

        float axis = 1;

        // Z = axe arrière/avant
        speedZ = Input.GetAxis("Vertical") * runningSpeed;
        // X = axe gauche/droite
        float speedX = Input.GetAxis("Horizontal") * runningSpeed;

        // Y = axe haut/bas
        float speedY = moveDirection.y;

        Velocity = Mathf.Sqrt(Mathf.Abs(speedX * speedX) + Mathf.Abs(speedZ * speedZ));
        Velocity *= speedMultiplier;

        float VelocityForward = Mathf.Clamp(speedZ, 0, Mathf.Infinity);

        TWODNUTS.emissionRate = Mathf.Clamp(VelocityForward - 5, 0, 30) * 2;
        playerCamera.fieldOfView = Mathf.Lerp(MinFOV, MaxFOV, VelocityForward / runningSpeed);

        //Calcul du mouvement
        //forward = axe arrière/avant
        //right = axe gauche/droite
        moveDirection =  (forward * speedZ + right * speedX) * speedMultiplier;


        // Est-ce qu'on appuie sur le bouton de saut (ici : Espace)
        if (Input.GetButton("Jump") && (characterController.isGrounded || StateMachine.GetBool("isWallRunning")))
        {
            StateMachine.SetBool("isJumping", true);
        }else
        {
            StateMachine.SetBool("isJumping", false);
            moveDirection.y = speedY;
        }

        if (Input.GetButton("Crouch"))
        {
            StateMachine.SetBool("isSliding", true);
        }
        else
        {
            StateMachine.SetBool("isSliding", false);
            StateMachine.SetBool("isCrouching", false);
        }


        //Si le joueur ne touche pas le sol
        if (!characterController.isGrounded)
        {
            //Applique la gravité * deltaTime
            //Time.deltaTime = Temps écoulé depuis la dernière frame
            moveDirection.y -= gravity * Time.deltaTime;
        }
        
        //Applique le mouvement
        characterController.Move(moveDirection * Time.deltaTime);

        
        //Rotation de la caméra

        //Input.GetAxis("Mouse Y") = mouvement de la souris haut/bas
        //On est en 3D donc applique ("Mouse Y") sur l'axe de rotation X 
        rotationX += -Input.GetAxis("Mouse Y") * rotationSpeed;

        //La rotation haut/bas de la caméra est comprise entre -45 et 45 
        //Mathf.Clamp permet de limiter une valeur
        //On limite rotationX, entre -rotationXLimit et rotationXLimit (-45 et 45)
        rotationX = Mathf.Clamp(rotationX, -rotationXLimit, rotationXLimit);


        //Applique la rotation haut/bas sur la caméra
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);


        //Input.GetAxis("Mouse X") = mouvement de la souris gauche/droite
        //Applique la rotation gauche/droite sur le Player
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * rotationSpeed, 0);
        

        if (StateMachine.GetBool("isWallRunning"))
        {
            StartCoroutine (afterRun());
        }
        
        StateMachine.SetFloat("SpeedPlayer", Velocity);
    }
    
    private void GetSmoothRawAxis(string name, ref float axis, float sensitivity, float gravity)
    {
        var r = Input.GetAxisRaw(name);
        var s = sensitivity;
        var g = gravity;
        var t = Time.deltaTime;
 
        if (r != 0)
        {
            axis = Mathf.Clamp(axis + r * s * t, -1f, 1f);
        }
        else
        {
            axis = Mathf.Clamp01(Mathf.Abs(axis) - g * t) * Mathf.Sign(axis);
        }
    }
    
    IEnumerator afterRun()
    {
        yield return new WaitForSeconds(runTime);
        StateMachine.SetBool("isWallRunning", false);
    }
    
}
