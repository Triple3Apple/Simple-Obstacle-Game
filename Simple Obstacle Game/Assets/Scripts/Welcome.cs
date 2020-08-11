using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Welcome : MonoBehaviour
{
    [SerializeField] private Animator _transition = null;
    [SerializeField] private float _transitionDuration = 2f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
        else if (Input.GetKey(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 2));
        }
        else if (Input.GetKey(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 3));
        }
    }

    public void StartGame()
    {
        Debug.Log("START GAME!");
        LoadNextLevel();
    }

    public void Testttt()
    {
        Debug.Log("Button Pressed");
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    // Loads level afetr some time (to allow animation/level transition to play before changing scene)
    IEnumerator LoadLevel(int levelIndex)
    {
        // play animation
        _transition.SetTrigger("Start");    // parameter inside the animator (custom)

        // wait (pauses couroutine for x seconds)
        yield return new WaitForSeconds(_transitionDuration);

        // load scene
        SceneManager.LoadScene(levelIndex);
    }
}

// https://github.com/Triple3Apple