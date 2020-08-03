using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{

    [SerializeField] private GameManager _gameManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _gameManager.GetPlayerDeadBool() == false) 
        { 
            _gameManager.CompleteLevel(); 
        }
    }
}
