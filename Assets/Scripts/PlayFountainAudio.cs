using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFountainAudio : MonoBehaviour
{
    public GameObject fountain;
    public GameObject portal;
    AudioSource fountainAudio;
    AudioSource portalAudio;
    void Start()
    {
        fountainAudio = fountain.GetComponent<AudioSource>();
        fountainAudio.Stop();
        portalAudio = portal.GetComponent<AudioSource>();
        portalAudio.Play();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            fountainAudio.Play();
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            portalAudio.Play();
        }
    }  
}
