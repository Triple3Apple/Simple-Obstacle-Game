using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;      // Added for restarting scene/level
using UnityEngine;
using System.Dynamic;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool _gameHasEnded = false;

    [SerializeField] private float _restartDelay = 2f;

    [SerializeField] private GameObject _completeLevelUI = null;

    private bool _hasPlayerDied = false;

    public bool isLevelCompleted = false;

    public void EndGame()
    {
        if (!_gameHasEnded)
        {
            _gameHasEnded = true;
            _hasPlayerDied = true;
            Debug.Log("Game Over");
            Invoke("Restart", _restartDelay);    // will invoke method after _restartDelay number of seconds
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
        _completeLevelUI.SetActive(true);
    }

    public bool GetPlayerDeadBool()
    {
        return _hasPlayerDied;
    }
}
