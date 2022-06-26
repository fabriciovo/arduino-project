using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;
    void Awake(){
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        // Add + 1 to player's last known position so bullet appears to float above ground.
         rb.AddForce(transform.forward * 400f);
    }


}
