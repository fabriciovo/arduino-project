using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int score { get; set; }
    [SerializeField] private CharacterController controller;

    void Update()
    {
        controller.Move(transform.forward * 20f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ring")
        {
            score++;
            Destroy(other.gameObject);
        }
    }
}
