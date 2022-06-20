using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 20f;
    // Start is called before the first frame update
    private Rigidbody m_Rigidbody;
    private CharacterController controller;
    [SerializeField] Transform cam;
    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    private float smoothSpeed;
    Vector3 direction;
    float gravityForce = 10f;
    private bool grounded = true;
    public LayerMask whatIsGround;
    public float groundRayLenght;
    public Transform groundRayPoint;
    private float vSpeed;
    private float hSpeed;
    private float jump;
    float dir = 0;

    Animator animator;

    [SerializeField] GameObject sonic;
    [SerializeField] GameObject sonicSpin;

    void Awake() {
        sonicSpin.SetActive(false);
    }

    void Start()
    {

        m_Rigidbody = GetComponent<Rigidbody>();
        animator = sonic.GetComponent<Animator>();
    }

    void Update()
    {
        jump = 0;
        hSpeed = 0;
        vSpeed = 0;
        if (Input.GetAxis("Vertical") > 0)
        {
            vSpeed = Input.GetAxis("Vertical") * speed * 1000f;
            dir = 180;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            vSpeed = Input.GetAxis("Vertical") * speed * 1000f;
            dir = 0;

        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            hSpeed = Input.GetAxis("Horizontal") * speed * 1000f;
            dir = -90;

        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            hSpeed = Input.GetAxis("Horizontal") * speed * 1000f;
            dir = 90;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            jump = 10000f;
        }
   
    if( hSpeed ==0 && vSpeed == 0){
        animator.SetBool("movement", false);
    }else{
        animator.SetBool("movement", true);
    }

        if (grounded)
        {
            m_Rigidbody.MoveRotation(Quaternion.Euler(0, dir, 0));
            sonicSpin.SetActive(false);
            sonic.SetActive(true);
        }

    }
    private void FixedUpdate()
    {
        grounded = false;
        RaycastHit hit;

        if (Physics.Raycast(groundRayPoint.position, -transform.up, out hit, groundRayLenght, whatIsGround))
        {
            grounded = true;
        }

        if (grounded)
        {
            m_Rigidbody.drag = 4f;
            if (Mathf.Abs(vSpeed) > 0 || Mathf.Abs(hSpeed) > 0 || jump > 0)
            {
                m_Rigidbody.AddForce(new Vector3(vSpeed, jump, hSpeed * -1) * 0.5f);
            }
        }
        else
        {
            sonicSpin.SetActive(true);
            sonic.SetActive(false);
            m_Rigidbody.drag = 2f;
            if (Mathf.Abs(vSpeed) > 0 || Mathf.Abs(hSpeed) > 0 || jump > 0)
            {
                m_Rigidbody.AddForce(new Vector3(vSpeed, -gravityForce, hSpeed * -1) * 0.5f);
            }
        }
    }

    void OnMessageArrived(string msg)
    {
        Debug.Log("Message: " + msg);
        if (msg == "L")
        {
            direction = new Vector3(0f, 0f, 1f).normalized;
            //transform.rotation = Quaternion.Euler(0f, 90, 0f);
        }
        if (msg == "R")
        {
            direction = new Vector3(0f, 0f, -1f).normalized;
            //transform.rotation = Quaternion.Euler(0f, -90, 0f);
        }
        if (msg == "D")
        {
            direction = new Vector3(-1f, 0f, 0f).normalized;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if (msg == "U")
        {
            direction = new Vector3(1f, 0f, 0f).normalized;
            // transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

    }

    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device connected" : "Device disconnected");
    }
}
