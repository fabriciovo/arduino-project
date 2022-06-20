using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private CharacterController controller;
    private Vector3 velocity;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = GetComponent<CharacterController>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        Quaternion fastlook = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, fastlook, Time.deltaTime*3);
        velocity = direction * 3;

        controller.Move(velocity * Time.deltaTime);
    }
}
