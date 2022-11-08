using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField] GameObject toDestroy;

    [SerializeField] private ParticleSystem collectParticle;
    [SerializeField] private AudioClip collectSound;
    [SerializeField] private AudioSource audioSource; 

    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "collect")
        {
            collectParticle.gameObject.SetActive(true);
            audioSource.PlayOneShot(collectSound);
            Destroy(toDestroy , .5f);

            // add a body part to the snake / we try to access to the SnakeMovement Script 
            other.transform.parent.GetComponent<SnakeMovement>().AddBodyPart();
            
            //here i added score to the player
            GameManager.Instance.AddScore(1);

            Debug.Log(other.gameObject);
            
        }
    }
}
