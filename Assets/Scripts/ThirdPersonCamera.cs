using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 5;
    public float zoomSpeed = 2;
    public float rotationSpeed = 200;
    public float minDistance = 2f;
    public float maxDistance = 10f;
    public float playerHeight = 2;
    
    private float currentYaw = 0;
    
    void LateUpdate()
    {
        //zoom 
        var scroll = Input.GetAxis("Mouse ScrollWheel");
        distance -= scroll * zoomSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
        
        //rotate
        if (Input.GetMouseButton(1))
        {
            currentYaw += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        }
        
        var rotation = Quaternion.Euler(30f, currentYaw, 0);
        var offset = rotation * (Vector3.forward * -distance);
        
        transform.position = target.position + offset + Vector3.up * playerHeight;
        transform.LookAt(target.position + Vector3.up * playerHeight);
    }
}
