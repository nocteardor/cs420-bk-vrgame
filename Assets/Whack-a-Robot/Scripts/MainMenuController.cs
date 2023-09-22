using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{


    private void PlayButton()
    {
        Debug.Log("Main Gameplay Scene Loaded");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void QuitToDesktop() {
        Debug.Log("Game Quit");
        Application.Quit();
    }
}
