using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform = null;
    [SerializeField] private Vector3 _offset;        // camera offset

    // Update is called once per frame
    void Update()
    {
        transform.position = _playerTransform.position + _offset;
    }
}
