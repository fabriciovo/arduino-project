using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private Rigidbody rb;
    void Awake(){
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
         rb.AddForce(transform.forward * 400f);
    }


}
