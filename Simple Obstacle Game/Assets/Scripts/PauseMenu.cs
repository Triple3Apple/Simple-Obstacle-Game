using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    [SerializeField] private GameObject pauseMenuUI = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void GoToMainMenu()
    {
        // un-freeze time
        Time.timeScale = 1f;
        Debug.Log("going to main menu");
        Destroy(FindObjectOfType<MusicPlayer>());
        SceneManager.LoadScene(0);          // first index (main menu)
    }

    public void ResumeGame()
    {
        // remove pause menu
        pauseMenuUI.SetActive(false);

        // un-freeze time
        Time.timeScale = 1f;

        gameIsPaused = false;
    }

    void PauseGame()
    {
        // enable/show pause menu
        pauseMenuUI.SetActive(true);

        // freeze time
        Time.timeScale = 0f;

        gameIsPaused = true;
    }
}

// https://github.com/Triple3Apple