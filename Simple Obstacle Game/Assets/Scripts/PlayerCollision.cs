using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    [SerializeField] PlayerMovement playerMoveScript = null;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            Debug.Log("Obstacle Hit");

            //GetComponent<PlayerMovement>().enabled = false;       // works but slower by a bit
            playerMoveScript.enabled = false;   // when you hit an obstacle, movement is turned off

            // Used this instead of referencing via serializefield
            // This allows us to get GameManager even if new player object is created
            FindObjectOfType<GameManager>().EndGame();
        }



    }
}
