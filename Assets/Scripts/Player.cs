using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int rings { get; set; }
    [SerializeField] private CharacterController controller;

    [SerializeField] private Transform groundCheck;
    private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    private bool isGrounded = false;
    private Vector3 velocity;
    public bool jump = false;

    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        rings = 10;
    }

    private float gravity = -17.81f;
    void Update()
    {
        controller.Move(transform.forward * 20f * Time.deltaTime);
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0){
            velocity.y = -2f; 
        }
        
        if (rings <= 0)
        {
            GameOver();
        }
        if (isGrounded && jump)
        {
            velocity.y = Mathf.Sqrt(6f * -2f * gravity);
            jump = false;
            
        }
        if(!isGrounded)
        {
            animator.SetBool("jump", true);
        }
        else
        {
            animator.SetBool("jump", false);

        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    private void GameOver()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ring")
        {
            rings++;
            Destroy(other.gameObject);
        }
        if (other.tag == "Enemy")
        {
            rings--;
            Destroy(other.gameObject);
        }
    }

    void OnMessageArrived(string msg)
    {
        Debug.Log("moving at speed: " + msg);
        jump = true;
        animator.SetBool("jump", true);


    }

    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device connected" : "Device disconnected");
    }
}
