using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;      // Added for restarting scene/level
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool gameHasEnded = false;

    [SerializeField] private float restartDelay = 2f;

    [SerializeField] private GameObject completeLevelUI = null;

    public bool isLevelCompleted = false;

    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            Invoke("Restart", restartDelay);    // will invoke method after restartDelay number of seconds
        }
        
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);     // restarts current scene! (no strings)
    }

    public void CompleteLevel()
    {
        isLevelCompleted = true;
        Debug.Log("Level Completed");
        completeLevelUI.SetActive(true);
    }
}
