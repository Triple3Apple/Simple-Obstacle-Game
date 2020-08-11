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
    [SerializeField] private Animator _transition = null;
    [SerializeField] private float _transitionDuration = 2f;
    [SerializeField] private PlayerMovement _playerMoveScript = null;


    private GameObject _musicPlayer = null;

    private bool _hasPlayerDied = false;

    public bool isLevelCompleted = false;

    private void Start()
    {
        // find music player, will be destroyed once player is in new level
        _musicPlayer = GameObject.FindGameObjectWithTag("Music Player");
    }

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
        StartCoroutine(RestartLevel());
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

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void DestroyMusicPlayer()
    {
        Destroy(_musicPlayer);
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // play animation
        _transition.SetTrigger("Start");    // parameter inside the animator (custom)

        // wait (pauses couroutine for x seconds)
        yield return new WaitForSeconds(_transitionDuration);

        DestroyMusicPlayer();

        // load scene
        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator RestartLevel()
    {
        // play animation
        _transition.SetTrigger("Start");    // parameter inside the animator (custom)

        // wait
        yield return new WaitForSeconds(_transitionDuration);

        // re-load scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);     // restarts current scene! (no strings)
    }
}

// https://github.com/Triple3Apple