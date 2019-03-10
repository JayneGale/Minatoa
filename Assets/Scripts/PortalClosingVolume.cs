using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PortalClosingVolume : MonoBehaviour
{

    public GameObject player;
    public GameObject fountain;
    public GameObject portalDoor;
 //   public float fadeTime;
    float fountainMaxVol;
    float portalMaxVol;
    AudioSource fountainAudio;
    AudioSource portalAudio;
    AudioSource onAudio;
    AudioSource rampAudio;
    Animator portalAnimator;
    float portalDoorPos;
    float playerPos;
    bool insideRoom;
    bool isOpening;
    float volumeSetting;
    int upOrDown;

    // Start is called before the first frame update
    void Start()
    {
        portalAnimator = gameObject.GetComponent<Animator>();
        portalAudio = gameObject.GetComponent<AudioSource>();
        portalMaxVol = portalAudio.volume;
        fountainAudio = fountain.GetComponent<AudioSource>();
        fountainMaxVol = fountainAudio.volume;
        playerPos = player.transform.position.x;
        insideRoom = (playerPos < portalDoorPos) ? true : false;
        onAudio = (insideRoom) ? fountainAudio : portalAudio;
        onAudio.volume = (insideRoom) ? fountainMaxVol : portalMaxVol;
        onAudio.Play();
        rampAudio = (insideRoom) ? portalAudio : fountainAudio;
        rampAudio.volume = 0.0f;
        rampAudio.Stop();
    }

    void PortalAnimating()
    {
        isOpening = portalAnimator.GetBool("isOpening");
        upOrDown = (isOpening) ? 1 : -1;
        portalDoorPos = portalDoor.transform.position.x;
        playerPos = player.transform.position.x;
        insideRoom = (playerPos < portalDoorPos) ? true : false;
        onAudio = (insideRoom) ? fountainAudio : portalAudio;
        onAudio.volume = (insideRoom) ? fountainMaxVol : portalMaxVol;
        onAudio.Play();
        rampAudio = (insideRoom) ? portalAudio : fountainAudio;

        if (rampAudio.volume >= 0.0f && rampAudio.volume <= 1.0f)
        {
            rampAudio.volume -= upOrDown * Time.deltaTime;
        }
    }
}