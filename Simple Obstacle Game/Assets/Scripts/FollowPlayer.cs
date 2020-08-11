using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform = null;
    [SerializeField] private Vector3 _offset;        // camera offset

    void Update()
    {
        transform.position = _playerTransform.position + _offset;
    }
}

// https://github.com/Triple3Apple
