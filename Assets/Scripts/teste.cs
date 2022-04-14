using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teste : MonoBehaviour
{
    public PlayerController player;

    void Start() // Start is called before the first frame update
    {

    }
    void Update() // Update is called once per frame
    {
    }
    void OnMessageArrived(string msg)
    {
        Debug.Log("moving at speed: " + msg);
        float speed = float.Parse(msg) * 100;
        player.jump = true;
    }
    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device connected" : "Device disconnected");
    }
}