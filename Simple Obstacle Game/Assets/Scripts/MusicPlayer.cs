using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{

    [SerializeField] float _maxMusicVolume = 75f;
    [SerializeField] float _fadeInSpeed = 0.5f;

    void Awake()
    {
        SetUpSingleton();
        StartCoroutine(FadeIn(_fadeInSpeed));
    }

    private void SetUpSingleton()
    {
        // getting type of this class
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    IEnumerator FadeIn (float fadeSpeed)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0f;
        float maxAudioVolume = _maxMusicVolume;
        float initialVolume = 0;

        while (initialVolume < maxAudioVolume)
        {
            initialVolume += fadeSpeed;
            audioSource.volume = initialVolume;
            yield return new WaitForSeconds(0.5f);
        }

        Debug.Log("Music done fading!");
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
        Debug.Log("Destroyed Music player");
    }
}

// https://github.com/Triple3Apple