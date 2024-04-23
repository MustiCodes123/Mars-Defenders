using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    private bool isPaused = false; // Flag to track the game's pause state
    public Canvas gamePauseCanvas;
    public Canvas gameOverCanvas;

    public Text sourceText;
    public Text destinationText;

    private void Start()
    {
        // Ensure the pause canvas is initially disabled
        gamePauseCanvas.gameObject.SetActive(false);
        gameOverCanvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }

        if (sourceText == null || destinationText == null)
        {
            return;
        }

        destinationText.text = sourceText.text;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            Debug.Log("Game Paused");
            gamePauseCanvas.gameObject.SetActive(true); // Enable the canvas
        }
        else
        {
            Time.timeScale = 1f; // Resume the game
            Debug.Log("Game Resumed");
            gamePauseCanvas.gameObject.SetActive(false); // Disable the canvas
        }
    }
}
