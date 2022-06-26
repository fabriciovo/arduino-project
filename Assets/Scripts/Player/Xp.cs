using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xp : MonoBehaviour
{
    private float rotation = 3f;

    void Update()
    {
        transform.Rotate(0, rotation+=0.01f * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            Destroy(gameObject);
        }
    }
}
