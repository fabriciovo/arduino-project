using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //// Smoothly tilts a transform towards a target rotation.
        //float tiltAroundZ = Input.GetAxis("Horizontal") * 180;
        //float tiltAroundX = Input.GetAxis("Vertical") * -180;

        //// Rotate the cube by converting the angles into a quaternion.
        //Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);

        //// Dampen towards the target rotation
        //transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 5.0f);
        float tiltAroundZ = Input.GetAxis("Horizontal") / 2f;
        transform.Rotate(0, 0, tiltAroundZ, Space.Self);

        transform.gameObject.transform.position += new Vector3(-1 * Time.deltaTime, 0, 0);
    }
}

