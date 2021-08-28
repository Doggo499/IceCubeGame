using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public float waitTimer = 5f;

    public static bool gameIsPaused = false;
    private bool stopTimer = true;

    public GameObject pauseMenuUI;
    public GameObject loadingScreen;

    private void Start()
    {
        Resume();
    }

    private void Update()
    {
        if (stopTimer == false)
        {
            waitTimer -= Time.deltaTime;
        }

        if (waitTimer <= 0)
        {
            stopTimer = true;
            SceneManager.LoadScene("Level");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused == true)
            {
                Resume();
            }

            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
        }
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(true);
        }
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Play()
    {
        stopTimer = false;
        loadingScreen.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene("Level");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}