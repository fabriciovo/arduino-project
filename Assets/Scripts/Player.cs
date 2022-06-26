using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody m_Rigidbody;
    Vector3 direction;
    float gravityForce = 10f;
    private bool grounded = true;
    public LayerMask whatIsGround;
    public float groundRayLenght;
    public Transform groundRayPoint;

    private bool canJump;
    float dir = 0;

    Animator animator;

    private float vSpeed;
    private float hSpeed;
    private float jump;

    //Power Ups
    [SerializeField] private GameObject shoot;
    [SerializeField] private GameObject shield;
    [SerializeField] private GameObject bomb; 
   

     //Stats
    private float speed = 20f;
    private float life = 3;
    private float attackSpeed = 5;
    private float attackPower = 0.5f;
    private float cd = 0;
    void Awake() {
        
    }

    void Start()
    {

        m_Rigidbody = GetComponent<Rigidbody>();
    
    }

    void Update()
    {
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
   
        if(canJump){
            
             canJump = false;
             
        }
    if( hSpeed ==0 && vSpeed == 0){
        animator.SetBool("movement", false);
    }else{
        animator.SetBool("movement", true);
    }

        if (grounded)
        {
            m_Rigidbody.MoveRotation(Quaternion.Euler(0, dir, 0));
        }


        cd -= Time.deltaTime;
        if (cd <= 0)
        {
            cd = attackSpeed;

           GameObject newBullet = Instantiate(shoot, transform.position, transform.rotation);
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
            m_Rigidbody.drag = 2f;
            if (Mathf.Abs(vSpeed) > 0 || Mathf.Abs(hSpeed) > 0 || jump > 0)
            {
                m_Rigidbody.AddForce(new Vector3(vSpeed, -gravityForce, hSpeed * -1) * 0.5f);
            }
        }

        if(!canJump){
             jump = 0;
        }
    }

    void OnMessageArrived(string msg)
    {
        Debug.Log("Message: " + msg);
        if (msg == "L")
        {
            vSpeed = 1 * speed * 1000f;
            dir = 0;
        }
        if (msg == "R")
        {
            vSpeed = -1 * speed * 1000f;
            dir = 180;

        }
        if (msg == "D")
        {
            hSpeed = -1 * speed * 1000f;
            dir = -90;

        }
        if (msg == "U")
        {
            hSpeed = 1 * speed * 1000f;
            dir = 90;
        }
        if (msg == "Button")
        {   
            canJump =true;
            jump = 10000f;            
            
        }
       
    }

    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device connected" : "Device disconnected");
    }
}
