using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Welcome : MonoBehaviour
{

    [SerializeField] private Animator _transition = null;

    [SerializeField] private float _transitionDuration = 2f;


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
