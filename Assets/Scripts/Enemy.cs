using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject effect;
    private GameObject player;
    private bool grounded = false;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {


        // Rotate the camera every frame so it keeps looking at the target
        transform.LookAt(player.transform);

        if (GetComponent<NavMeshAgent>().isOnNavMesh)
        {
            GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "spin"){
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
