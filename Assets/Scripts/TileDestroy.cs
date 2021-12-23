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

    public static GameObject player2;
    public static Transform player;
    // Update is called once per frame
    void Update()
    {
        // if (
        //     Math.Abs(transform.position.z - player.position.z) < 80 &&
        //     Math.Abs(transform.position.x - player.position.z) < 80
        // )
        // {
        //     
        //     GameStatic.spawn.DecreaseTile();
        //     Destroy(gameObject,3);
        // }
        
        if (
            Math.Abs(transform.position.z - GameStatic.CharGameObject.transform.position.z) < 90 &&
            Math.Abs(transform.position.x - GameStatic.CharGameObject.transform.position.x) < 90
        )
        {
            
           deleteSpawn();
        }
    }

    void deleteSpawn()
    {
        GameStatic.spawn.DecreaseTile();
        Destroy(gameObject,4);
    }
}