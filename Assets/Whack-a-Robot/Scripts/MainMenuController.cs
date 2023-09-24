using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public int difficulty;

    private void Update()
    {
        
    }

    private void PlayButton()
    { 
        Debug.Log("Main Gameplay Scene Loaded");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void QuitToDesktop() {
        Debug.Log("Game Quit");
        Application.Quit();
    }

    private int DifficultyMenu(int difficulty)
    {
        Debug.Log("Difficulty Set to Easy");
        difficulty = 0;
        return difficulty;

    }

}
