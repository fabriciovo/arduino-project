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
    Vector3 direction;
    void Start()
    {

        //controller = GetComponent<CharacterController>();
        m_Rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

       
        if (Input.GetKey(KeyCode.A))
        {
            
            direction = new Vector3(0f, 0f, 1f).normalized;

        }
        if (Input.GetKey(KeyCode.D))
        {
            direction = new Vector3(0f, 0f, -1f).normalized;
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction = new Vector3(-1f, 0f, 0f).normalized;
        }
        if (Input.GetKey(KeyCode.W))
        {
            direction = new Vector3(1f, 0f, 0f).normalized;

        }
        if (Input.GetKey(KeyCode.Space) && !jump)
        {
            direction = new Vector3(0f, 3100f, 0f).normalized;
            jump = true;
        }

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            cam.rotation = Quaternion.Euler(0f, angle, 0f);
        }
         m_Rigidbody.AddForce(direction.normalized * speed * Time.deltaTime, ForceMode.Impulse);
        // direction = Vector3.zero;
    }

    void OnMessageArrived(string msg)
    {
        Debug.Log("Message: " + msg);
        if (msg == "L") {
            direction = new Vector3(0f, 0f, 1f).normalized;
        }
        if (msg == "R") {
            direction = new Vector3(0f, 0f, -1f).normalized;
        }
        if (msg == "D") {
            direction = new Vector3(-1f, 0f, 0f).normalized;
        }
        if(msg == "U") {
            direction = new Vector3(1f, 0f, 0f).normalized;
        }
 
    }

    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device connected" : "Device disconnected");
    }
}
