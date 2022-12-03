using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{

    [SerializeField] private ParticleSystem collectParticle;
    [SerializeField] private AudioSource audioSource; 

    void OnTriggerEnter(Collider other) 
    {
        //other.tag == "head"
        if(true)
        {
            if(collectParticle) collectParticle.gameObject.SetActive(true);
            // remove a ball when colliding with obstacles
            other.transform.gameObject.GetComponentInParent<SnakeMovement>().removeBodyPart();
        }
    }
}
