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

    public float minWait = 1.5f;
    public float maxWait = 2.5f;
    public float chanceToRise = 0.3f; // 30% chance to rise
    public float chanceToHide = 0.3f; // 50% chance to hide

    public float gameTime; // 60 Seconds
        
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
        Text scoreLabel = scoreObject.GetComponent<Text>();
        scoreLabel.text = score.ToString();

        foreach (RoMo romo in romos)
        {

            if (romo.isHit)
            {
                romo.DestroySafely();
                onMoleHit();

            }

        }


    }

    IEnumerator GameTime()
    {
        Text time = timerObject.GetComponent<Text>();
       
        if (mmc.difficulty == 0)
        {
            // Easy - 6 Minutes

            gameTime = 360f;
        }
        else if (mmc.difficulty == 1)
        {   
            // Medium - 4 Minutes

            gameTime = 240f;
        }
        else
        {
            // Hard - 2 Minutes

            gameTime = 120f;
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
