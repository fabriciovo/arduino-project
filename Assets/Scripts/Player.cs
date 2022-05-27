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
    private bool jump = false;

    private float smoothSpeed;
    Vector3 direction;
    float dir = 0;
    void Start()
    {

        //controller = GetComponent<CharacterController>();
        m_Rigidbody = GetComponent<Rigidbody>();

    }
    Vector3 currentEulerAngles;
    Quaternion currentRotation;
    // Update is called once per frame
    void Update()
    {

       
        if (Input.GetKey(KeyCode.A))
        {
            
            direction = new Vector3(0f, 0f, 1f).normalized;
            //transform.rotation = Quaternion.Euler(0f, 90, 0f);

        }
        if (Input.GetKey(KeyCode.D))
        {
            direction = new Vector3(0f, 0f, -1f).normalized;
            //transform.rotation = Quaternion.Euler(0f, -90, 0f);

        }
        if (Input.GetKey(KeyCode.S))
        {
            direction = new Vector3(-1f, 0f, 0f).normalized;
            //transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            direction = new Vector3(1f, 0f, 0f).normalized;
            //transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        if (Input.GetKey(KeyCode.Space) && !jump)
        {
            direction = new Vector3(0f, 3100f, 0f).normalized;
            jump = true;
        }

        //if (direction.magnitude >= 0.1f)
        //{
        //    float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
        //    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        //    transform.rotation = Quaternion.Euler(0f, angle, 0f);
        //}

        if (direction.magnitude > 0) { 
            smoothSpeed = Mathf.Lerp(smoothSpeed, 0.1f, Time.deltaTime);
            //t_mesh.rotation Quaternion.LookRotation(velocity);
            cam.rotation = Quaternion.Lerp(cam.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 10f);

        }

        // direction = Vector3.zero;
    }
    private void FixedUpdate()
    {
        m_Rigidbody.AddForce(direction.normalized * speed * Time.deltaTime, ForceMode.Impulse);
    }

    private void LateUpdate()
    {
        transform.Rotate(0f, dir, 0f);
        dir = 0;
    }


    void OnMessageArrived(string msg)
    {
        Debug.Log("Message: " + msg);
        if (msg == "L") {
            direction = new Vector3(0f, 0f, 1f).normalized;
            //transform.rotation = Quaternion.Euler(0f, 90, 0f);
        }
        if (msg == "R") {
            direction = new Vector3(0f, 0f, -1f).normalized;
            //transform.rotation = Quaternion.Euler(0f, -90, 0f);
        }
        if (msg == "D") {
            direction = new Vector3(-1f, 0f, 0f).normalized;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if(msg == "U") {
            direction = new Vector3(1f, 0f, 0f).normalized;
           // transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
 
    }

    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device connected" : "Device disconnected");
    }
}
