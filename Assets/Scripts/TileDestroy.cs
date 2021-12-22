using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject player;
    // Update is called once per frame
    void FixedUpdate()
    {
        // if (
        //     
        //     Math.Abs( transform.position.z -GameStatic.CharGameObject.transform.position.z)<10&&
        //     Math.Abs( transform.position.z -GameStatic.CharGameObject.transform.position.z)<10
        //     
        //     )
        // {
        
        GameStatic.spawn.DecreaseTile();
        Destroy(gameObject,5);
        
    }
}
