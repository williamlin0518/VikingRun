using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public static GameManager inst;

    public Text scoreText;
    private void Awake()
    {
        inst = this;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
