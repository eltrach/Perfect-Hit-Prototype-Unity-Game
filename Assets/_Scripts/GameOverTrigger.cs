using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{

    [SerializeField] private ParticleSystem collectParticle;
    [SerializeField] private AudioClip GameOver;
    [SerializeField] private AudioSource audioSource; 

    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "collect")
        {
            collectParticle.gameObject.SetActive(true);
            audioSource.PlayOneShot(GameOver);

            // Kill The Player and End The Game 
            GameManager.Instance.GameOver();


        }
    }
}
