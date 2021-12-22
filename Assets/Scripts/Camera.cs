using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
    }
    
    private Vector3 followPos;
    public Transform target;

    public float trailDistance = 3.0f;
    
    public float heightOffset = 3.0f;

    //private Vector3 distance = new Vector3(0, 0, 0);
    public float cameraDelay = 0.02f;
    // Update is called once per frame
    

    // private void Update()
    // {
    //     
    //     followPos = target.position-target.forward*trailDistance  ;
    //     followPos.y += heightOffset;
    //     transform.position += (followPos - transform.position) * cameraDelay;
    //     transform.LookAt(target.transform);
    // }
    
    void LateUpdate()
    {
         followPos = target.position-target.forward*trailDistance  ;
         followPos.y += heightOffset;
        
         transform.position = Vector3.Lerp(transform.position, followPos, Time.deltaTime);
         transform.LookAt(target.transform);
        
        // Vector3 currentPosition = transform.position;
        //
        // transform.position = currentPosition * (Vector3.forward );
        
    }
}
