using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool canPlay = false;
    private bool detected = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canPlay)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                canPlay = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && !detected)
            {
                //Attack();

            }
        }
    }

    private void Attack()
    {
        Debug.Log("`Player Attack");
    }

    void OnMessageArrived(string msg)
    {
        Debug.Log("Detected " + msg);
   
    }

    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device connected" : "Device disconnected");
    }

}
