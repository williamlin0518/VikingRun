using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Transform target;

    public float trailDistance = 5.0f;

    public float heightOffset = 3.0f;

    public float cameraDelay = 0.02f;
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 followPos = target.position - target.forward * trailDistance;
        followPos.y += heightOffset;
        transform.position = Vector3.Lerp(transform.position, followPos, Time.deltaTime);
        
        transform.LookAt(target.transform);
        
    }
}
