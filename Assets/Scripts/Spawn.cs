using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update



    public GameObject tilePrefab;
    public GameObject referenceObject;   //this 

    public float distanceBetweenTile = 4.0f;

    //public float timeOffset = 4.0f;
    public float randomValue = 0.8f;

    private Vector3 prevTilePos;
    //private float startTime;

    private Vector3 direction = new Vector3(0, 0, 1);
    private Vector3 mainDirection = new Vector3(0, 0, 1);

    private Vector3 otherDirection = new Vector3(1, 0, 1);


    public int maxTileAmount = 5;

    private int thisTileAmount = 0;



    public GameObject obstacleWall;
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
        //if (Time.time - startTime > timeOffset) return;

        if (Random.value < randomValue)
        {
            direction = mainDirection;
        }
        else
        {
            Vector3 tmp = direction;
            direction = otherDirection;
            mainDirection = direction;
            otherDirection = tmp;
        }

        Vector3 newSpawnPos = prevTilePos + distanceBetweenTile * direction;    //new pos
        Transform spawnPoint = referenceObject.transform.GetChild(0 );
        GameObject temp=Instantiate(tilePrefab,spawnPoint.position, Quaternion.Euler(0, 90, 0));
        prevTilePos = newSpawnPos;
        referenceObject = temp;
        thisTileAmount++;


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
