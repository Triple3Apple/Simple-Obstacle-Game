using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Boost : MonoBehaviour
{
    [SerializeField] private float boostAmount = 5000f;
    [SerializeField] private GameObject _boostCameraEffect = null;
    [SerializeField] private int _boostEffectDurationSE = 3;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Boost Activated");
            other.GetComponent<Rigidbody>().AddForce(0, (boostAmount*10) * Time.deltaTime, (boostAmount*10) * Time.deltaTime);


            //boost effect
            _boostCameraEffect.SetActive(true);
            Debug.Log("boost effect ACTIVATED");
            StartCoroutine(DisableBoost());

        }
    }

    // Boost camera effect lasts for time given
    IEnumerator DisableBoost()
    {
        // disable effect after time specified
        Debug.Log("Waiting for " + _boostEffectDurationSE + " seconds");

        AudioSource audioSource = GetComponent<AudioSource>();

        AudioClip audioClip = audioSource.clip;
        audioSource.PlayOneShot(audioClip);

        yield return new WaitForSeconds(_boostEffectDurationSE);

        _boostCameraEffect.SetActive(false);    // turn off effect
        Debug.Log("boost effect DISABLED");
    }
}

// https://github.com/Triple3Apple