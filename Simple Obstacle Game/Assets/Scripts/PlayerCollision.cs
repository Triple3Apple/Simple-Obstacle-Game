using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    [SerializeField] private PlayerMovement _playerMoveScript = null;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            Debug.Log("Obstacle Hit");

            //GetComponent<PlayerMovement>().enabled = false;       // works but slower by a bit
            _playerMoveScript.enabled = false;   // when you hit an obstacle, movement is turned off

            // enable rotation on y and z axis when player hits a obstacle
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.None;  


            // Used this instead of referencing via serializefield
            // This allows us to get GameManager even if new player object is created

            // only end game if level is not completed (this prevents level from restarting when player finishes game and then hits a obstacle)
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (!gameManager.isLevelCompleted)
            {
                gameManager.EndGame();
            }
            
            
            //FindObjectOfType<GameManager>().EndGame();
        }
    }

    public void killPlayer()
    {
        Debug.Log("Obstacle Hit");

        _playerMoveScript.enabled = false;   // when you hit an obstacle, movement is turned off

        // enable rotation on y and z axis when player hits a obstacle
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.None;

        // only end game if level is not completed (this prevents level from restarting when player finishes game and then hits a obstacle)
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (!gameManager.isLevelCompleted)
        {
            gameManager.EndGame();
        }
    }
}
