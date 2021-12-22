using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject tilePrefabRight;
    public GameObject tilePrefabLeft;
    public GameObject tilePrefab;
    public GameObject referenceObject;   //this 

    public float distanceBetweenTile = 4.0f;

    
    private Vector3 prevTilePos;
    

    private Vector3 direction = new Vector3(0, 0, 1);
    private Vector3 mainDirection = new Vector3(0, 0, 1);

    private Vector3 otherDirection = new Vector3(1, 0, 0);
    //private Vector3 leftDirection = new Vector3(-1, 0, 0);


    public int maxTileAmount = 5;
    private int thisTileAmount = 0;

    
    private Vector3 newSpawnPos;

    private GameObject temp;
    
    void Start()
    {
        prevTilePos = referenceObject.transform.position;
        //startTime = Time.time;
        SpawnObstacle();
    }

    private void Awake()
    {
        GameStatic.spawn = this;
    }
    // Update is called once per frame


    void Update()
    {
        if (thisTileAmount > maxTileAmount)
        {
            return;
        }
        
        
        
        
        float randomValue = Random.value;
        if (randomValue < 1&&randomValue>0.4)
        {
            direction = mainDirection;                   // straight
            newSpawnPos = prevTilePos + distanceBetweenTile * direction;    //new pos
            Transform spawnPoint = referenceObject.transform.GetChild(0 );
            temp=Instantiate(tilePrefab,spawnPoint.position, Quaternion.Euler(0, 90, 0));
        }
        else if(randomValue>0.2)
        {
            //Vector3 tmp = direction;                    //right
            //direction = otherDirection;
            //mainDirection = direction;
            //otherDirection = tmp;
            direction = mainDirection; 
            
            newSpawnPos = prevTilePos + distanceBetweenTile * direction;    //new pos
            Transform spawnPoint = referenceObject.transform.GetChild(0 );
            temp=Instantiate(tilePrefabRight,spawnPoint.position, Quaternion.Euler(0, 180, 0));
        }
        else
        {
            // Vector3 tmp = direction;                    //left
            // direction = otherDirection;
            // mainDirection = direction;
            // otherDirection = tmp;
            direction = mainDirection; 
            newSpawnPos = prevTilePos + distanceBetweenTile * direction;    //new pos
            Transform spawnPoint = referenceObject.transform.GetChild(0 );
            temp=Instantiate(tilePrefabLeft,spawnPoint.position, Quaternion.Euler(0, 90, 0));
        }

        // Vector3 newSpawnPos = prevTilePos + distanceBetweenTile * direction;    //new pos
        // Transform spawnPoint = referenceObject.transform.GetChild(0 );
        // GameObject temp=Instantiate(tilePrefab,spawnPoint.position, Quaternion.Euler(0, 90, 0));
        prevTilePos = newSpawnPos;
        referenceObject = temp;
        thisTileAmount++;


    }

    public void ProduceSpawn()
    {
        
    }

    public void DecreaseTile()
    {
        thisTileAmount--;
    }

    void SpawnObstacle()
    {
        //if (Random.value < 0.2)
        //{
            // Transform spawnPoint = transform.GetChild(1);
            //
            // Instantiate(obstacleWall, spawnPoint.position, Quaternion.identity, transform);

        //}
    }
}
