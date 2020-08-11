using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        Debug.Log("going to main menu");
        SceneManager.LoadScene(0);          // first index (main menu)

    }
}

// https://github.com/Triple3Apple