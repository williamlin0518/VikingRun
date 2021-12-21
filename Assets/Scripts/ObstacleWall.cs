using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleWall : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obstacleWall;

    public GameObject obstacleRoBlue;
    public GameObject obstacleRoGreen;
    //public float number = Random.value;
    void Start()
    {
        float a = Random.value;
        if (a< 0.2)
        {
            Transform spawnPoint = transform.GetChild(1);
            
            //Destroy(obstacleWa);
            Instantiate(obstacleWall, spawnPoint.position, Quaternion.identity, transform);

        }
        else if (a > 0.2 && a < 0.3)
        {
            Transform spawnPoint = transform.GetChild(2);
            
            //Destroy(obstacleWa);
            Instantiate(obstacleRoBlue, spawnPoint.position, Quaternion.identity, transform);
        }
        else if (a > 0.3 && a < 0.4)
        {
            Transform spawnPoint = transform.GetChild(2);
            
            //Destroy(obstacleWa);
            Instantiate(obstacleRoGreen, spawnPoint.position, Quaternion.identity, transform);
        }
    }

    //public GameObject obstacleWall;
    // Update is called once per frame
    void Update()
    {
        // if (Random.value < 0.1)
        // {
        //     Transform spawnPoint = transform.GetChild(1);
        //     
        //     //Destroy(obstacleWa);
        //     Instantiate(obstacleWall, spawnPoint.position, Quaternion.identity, transform);
        //
        // } 
    }
}
