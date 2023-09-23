using Meta.WitAi;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public MainMenuController mmc;
    public Canvas mainCanvas;

    public RoMo[] romos;

    public float minWait = 0.5f;
    public float maxWait = 1.5f;
    public float chanceToRise = 1f; // 100% chance to rise
    public float chanceToHide = 0.5f; // 50% chance to hide

    public float gameTime;
        
    private int score = 0;
    private int pointsOnHit = 20;
    
    private bool started = false;


    public GameObject timerObject;
    public GameObject scoreObject;


    // Start is called before the first frame update
    void Start()
    {   
        started = true;

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
       // Text scoreLabel = scoreObject.GetComponent<Text>();
       // scoreLabel.text = score.ToString();
       

        // LINQ for interating through the array of RoMos

        foreach (RoMo romo in romos)
        {

            if (romo.isHit)
            {
                onMoleHit();

            }

        }


    }

    IEnumerator GameTime()
    {
        Text time = timerObject.GetComponent<Text>();
       
        if (mmc.difficulty == 0)
        {
            // Easy - 3 Minutes

            gameTime = 240f;
        }
        else if (mmc.difficulty == 1)
        {   
            // Medium - 2 Minutes

            gameTime = 120f;
        }
        else
        {
            // Hard - 1 Minute

            gameTime = 60f;
        }

        while (gameTime > 0);
        yield return new WaitForSeconds(1);
        gameTime--;

        time.text = gameTime.ToString();
       
    }

    IEnumerator RomoLoop()
    {
        while (true)
        {

            foreach (RoMo romo in romos)
            {

                if (UnityEngine.Random.value < chanceToRise)
                {
                    romo.RiseMole();
                }

                if (UnityEngine.Random.value < chanceToHide)
                {
                    romo.HideMole();
                }

            }
            yield return new WaitForSeconds(UnityEngine.Random.Range(minWait, maxWait));
        }

    }

    private void onMoleHit()

    {

        AddScore(pointsOnHit);

    }

    public void AddScore(int points)
    {
        score += points;
    }
}
