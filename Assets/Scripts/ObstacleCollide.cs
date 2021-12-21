using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleCollide : MonoBehaviour
{
    // Start is called before the first frame update

    private playerMove playerMove;
    void Start()
    {
        playerMove = GameObject.FindObjectOfType<playerMove>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if (collision.gameObject.name == "viking")
        // {
        //     playerMove.Die();
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
