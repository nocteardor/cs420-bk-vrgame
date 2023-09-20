using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    public float defaultHeight = 1.8f;

    [SerializeField]
    public Camera camera;

    private void Resize()
    {
        float headHeight = camera.transform.localPosition.y;
        float scale = defaultHeight / headHeight;
        transform.localScale = Vector3.one * scale;

    }
    private void OnEnable()
    {
        Resize();
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
}
