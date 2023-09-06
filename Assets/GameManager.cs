using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public RoMo romo;
    public float minWait = 1.5f;
    public float maxWait = 2.5f;
    public float gameTime = 60f; // 60 Seconds
        
    private int score = 0;
    private bool started = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!started) return;

        else
        {
            StartCoroutine(RomoLoop());
            StartCoroutine(GameTime());

        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GameTime()
    {
        while (gameTime > 0);
        yield return new WaitForSeconds(1);
        gameTime--;
    }

    IEnumerator RomoLoop()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(minWait, maxWait));
        romo.RiseMole();

    }

    public void AddScore(int points)
    {
        score += points;
    }
}
