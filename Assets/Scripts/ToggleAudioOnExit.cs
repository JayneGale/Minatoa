using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAudioPortalOpen : MonoBehaviour {

    public GameObject fountainToTrigger;
    public GameObject player;
    public GameObject portal;
    AudioSource fountainAudio;
    AudioSource portalAudio;
    Animator portalAnimator;
    bool fountainOn;
    float portalDoorPos;
    float playerPos;
    bool isOpening;
    bool insideRoom;

    void Start()
    {
        fountainAudio = fountainToTrigger.GetComponent<AudioSource>();
        portalAudio = portal.GetComponent<AudioSource>();
        portalAnimator = portal.GetComponent<Animator>();
        isOpening = portalAnimator.GetBool("isOpening");
        portalDoorPos = gameObject.transform.position.x;
        playerPos = player.transform.position.x;
     

        if (playerPos >= portalDoorPos)
        {
            portalAudio.Play();
            fountainAudio.Stop();
        }
 
        else 
        {
            portalAudio.Stop();
            fountainAudio.Play();
        }
    }
	
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerPos = player.transform.position.x;
            portalDoorPos = gameObject.transform.position.x;
            if (playerPos < portalDoorPos)
            {
                insideRoom = true;
            }
            else
            {
                insideRoom = false;
            }
            isOpening = portalAnimator.GetBool("isOpening");
            Debug.Log("isOpening is " + isOpening);

            if (isOpening && insideRoom)
            {
                portalAudio.Play();
            }
            if (isOpening && !insideRoom)
            {
                fountainAudio.Play();
            }            
        }
    }
}
