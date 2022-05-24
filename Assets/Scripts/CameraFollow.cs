using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    private float smoothSpeed = 0.125f;
    public Vector3 offset;
    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }



}
