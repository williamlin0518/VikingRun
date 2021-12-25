using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleWall : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obstacleWall;

    public GameObject obstacleRoBlue;
    public GameObject obstacleRoGreen;
    public GameObject coin;
    //public float number = Random.value;
    void Start()
    {
        float a = Random.value;
        if (a<= 0.2)
        {
            Transform spawnPoint = transform.GetChild(Random.Range(3,9));
            
            //Destroy(obstacleWa);
            Instantiate(obstacleWall, spawnPoint.position, Quaternion.identity, transform);

        }
        else if (a > 0.2 && a <= 0.4)
        {
            Transform spawnPoint = transform.GetChild(Random.Range(3,9));
            
            //Destroy(obstacleWa);
            Instantiate(obstacleRoBlue, spawnPoint.position, Quaternion.identity, transform);
        }
        else if (a > 0.4 && a <= 0.55)
        {
            Transform spawnPoint = transform.GetChild(Random.Range(3,9));
            
            //Destroy(obstacleWa);
            Instantiate(obstacleRoGreen, spawnPoint.position, Quaternion.identity, transform);
        }
        else
        {
            Transform spawnPoint = transform.GetChild(Random.Range(3,5));
            Transform spawnPoint2 = transform.GetChild(Random.Range(5,7));
            Instantiate(coin, spawnPoint.position+new Vector3(0,3,0), Quaternion.Euler(0, 0, 90), transform);
            Instantiate(coin, spawnPoint2.position+new Vector3(0,3,0), Quaternion.Euler(90, 90, 90), transform);
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
