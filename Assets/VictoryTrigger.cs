using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryTrigger : MonoBehaviour
{
    [SerializeField] private ParticleSystem winParticle;
    [SerializeField] private AudioClip win;
    [SerializeField] private AudioSource audioSource; 

    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "collect")
        {
            winParticle.gameObject.SetActive(true);
            audioSource.PlayOneShot(win);

            // Kill The Player and End The Game 
            GameManager.Instance.Victory();


        }
    }


}
