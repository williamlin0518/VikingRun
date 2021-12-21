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

    // Update is called once per frame
    void FixedUpdate()
    {
        if (
            
            (int) transform.position.z ==(int) GameStatic.CharGameObject.transform.position.z
            
            )
        {
            GameStatic.spawn.DecreaseTile();
            Destroy(gameObject);
        }
    }
}
