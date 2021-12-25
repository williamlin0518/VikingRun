using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject deathUI;
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Die()
    {
        
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        deathUI.SetActive(true);
        Time.timeScale = 0f;
        
    }
}
