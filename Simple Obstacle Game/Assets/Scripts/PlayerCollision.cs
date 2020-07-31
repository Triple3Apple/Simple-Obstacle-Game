using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    [SerializeField] PlayerMovement playerMoveScript;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            Debug.Log("Obstacle Hit");
            playerMoveScript.enabled = false;   // when you hit an obstacle, movement is turned off
        }
    }
}
