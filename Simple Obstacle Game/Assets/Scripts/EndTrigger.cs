using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{

    [SerializeField] private GameManager _gameManager;
    private void OnTriggerEnter(Collider other)
    {
        _gameManager.CompleteLevel();
    }
}
