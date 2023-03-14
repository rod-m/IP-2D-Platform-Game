using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    void Start()
    {
        // capture the difference between camera and target
        offset = target.position - transform.position;
        // for 2D space retain the original z position
        offset.z = transform.position.z;
    }
    
    void LateUpdate()
    {
        // copy target position and add the offset
        transform.position = target.position + offset;
    }
}
