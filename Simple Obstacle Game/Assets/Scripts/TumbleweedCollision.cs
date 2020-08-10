using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumbleweedCollision : MonoBehaviour
{

    ParticleSystem particleSystem;
    List<ParticleCollisionEvent> particleCollisionEvents = new List<ParticleCollisionEvent>();

    [SerializeField] PlayerCollision playerCollisionScript;

    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnParticleCollision(GameObject other)
    {
        /*
        int numCollisionEvents = particleSystem.GetCollisionEvents(other, particleCollisionEvents);

        for (int i = 0; i < numCollisionEvents; i++)
        {
            if (other.CompareTag("Player"))
            {
                playerCollisionScript.killPlayer();
            }
            
        }
        */

        if (other.CompareTag("Player"))
        {
            playerCollisionScript.killPlayer();
        }
    }
}
