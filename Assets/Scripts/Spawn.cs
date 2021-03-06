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
    public GameObject coin;

    public float distanceBetweenTile = 4.0f;
    public float distanceBetweenTurn = 4.0f;

    
    private Vector3 prevTilePos;
    

    private Vector3 direction = new Vector3(0, 0, 1);
    private Vector3 mainDirection = new Vector3(0, 0, 1);

    private Vector3 otherDirection = new Vector3(1, 0, 0);
    //private Vector3 leftDirection = new Vector3(-1, 0, 0);


    private int maxTileAmount = 4;
    public static int thisTileAmount = 0;
    private int rotationAngle=90;
    private float limit = 0.15f;
    private Vector3 newSpawnPos;

    private GameObject temp;
    
    void Start()
    {
        maxTileAmount = 4;
        thisTileAmount = 0;
        prevTilePos = referenceObject.transform.position;
        //startTime = Time.time;
        SpawnObstacle();
    }

    private void Awake()
    {
        //GameStatic.spawn = this;
    }
    // Update is called once per frame
    private void Update()
    {
        if (thisTileAmount < maxTileAmount)
        {
            pro();
        }
        
    }

    public  void pro()
    {
        float randomValue = Random.value;
        if (thisTileAmount > maxTileAmount)
        {
            return;
        }
        
        
        if (randomValue <= 1&&randomValue>=0.3)
        {
            direction = mainDirection;                   // straight
            newSpawnPos = prevTilePos + distanceBetweenTile * direction;    //new pos
            Transform spawnPoint = referenceObject.transform.GetChild(0 );
            temp=Instantiate(tilePrefab,spawnPoint.position, Quaternion.Euler(0, rotationAngle, 0));
            thisTileAmount++;
        }
        else if(randomValue>limit)
        {
            if (limit < 0.25)
            {
                limit += 0.03f;
            }
            //Vector3 tmp = direction;                    //right
            //direction = otherDirection;
            //mainDirection = direction;
            //otherDirection = tmp;
            direction = Quaternion.Euler(0, 90, 0) * direction;
            //direction = mainDirection; 
            
            newSpawnPos = prevTilePos + distanceBetweenTurn * direction;    //new pos
            Transform spawnPoint = referenceObject.transform.GetChild(1 );
            rotationAngle += 90;
            temp=Instantiate(tilePrefabRight,spawnPoint.position, Quaternion.Euler(0, rotationAngle, 0));
            thisTileAmount++;
        }
        else
        {
            if (limit > 0.1f)
            {
                limit -= 0.03f;
            }
           
            
            direction = mainDirection; 
            newSpawnPos = prevTilePos + distanceBetweenTurn * direction;    //new pos
            Transform spawnPoint = referenceObject.transform.GetChild(2 );
            rotationAngle -= 90;
            temp=Instantiate(tilePrefabLeft,spawnPoint.position, Quaternion.Euler(0, rotationAngle, 0));
            thisTileAmount++;
            
            //Transform coinSpawnPoint = transform.GetChild(Random.Range(3,6));
            //Instantiate(coin, coinSpawnPoint.position+new Vector3(0,1,0), Quaternion.Euler(90, rotationAngle, 0), referenceObject.transform);
        }
        
        
        prevTilePos = newSpawnPos;
        referenceObject = temp;
        thisTileAmount++;
    }

    public void ProduceSpawn()
    {
        
    }

    public void DecreaseTile()
    {
        //thisTileAmount--;
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
