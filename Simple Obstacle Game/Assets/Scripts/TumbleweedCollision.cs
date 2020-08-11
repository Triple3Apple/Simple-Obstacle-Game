using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumbleweedCollision : MonoBehaviour
{

    ParticleSystem particleSystem;
    List<ParticleCollisionEvent> particleCollisionEvents = new List<ParticleCollisionEvent>();
    [SerializeField] PlayerCollision playerCollisionScript;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    // When player collides with tumbleweed particle, kill player
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            playerCollisionScript.killPlayer();
        }
    }
}

// https://github.com/Triple3Apple