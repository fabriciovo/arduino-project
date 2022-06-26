using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private CharacterController controller;
    private Vector3 velocity;
    [SerializeField] private GameObject laserEnemy;
    private float cd = 0;
    private float fireDelay = 5f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        if(!player) return;
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        Vector3 lookVector = player.transform.position - transform.position;
        lookVector.y = transform.position.y;
        Quaternion rot = Quaternion.LookRotation(lookVector);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);
        velocity = direction * 3;



        cd -= Time.deltaTime;
        if (cd <= 0 && player != null && Vector3.Distance(transform.position, player.transform.position) <90)
        {
            cd = fireDelay;

           GameObject newBullet = Instantiate(laserEnemy, transform.position, transform.rotation);
        }


        controller.Move(velocity * Time.deltaTime);

    }

}
