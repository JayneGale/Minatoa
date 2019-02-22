using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAudioOnExit : MonoBehaviour {

    public bool fountainOn;
    public GameObject fountainToTrigger;
    public GameObject player;
    public AudioSource FountainSound;
//    float doorPos;

    void Start()
    {
 //       doorPos = gameObject.transform.position.z;
        FountainSound = fountainToTrigger.GetComponent<AudioSource>();
        FountainSound.Stop();
        Debug.Log("fountainOn Start is " + fountainOn);

  /*      if (player.transform.position.z >= doorPos)
        {
            FountainSound.Stop();
        }
  */
    }
	
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("fountainOn OnTrigger Exit is " + fountainOn);
            fountainOn = !fountainOn;
            if (fountainOn)
            {
                FountainSound.Play();
            }
            else FountainSound.Stop();
        }
    }
}
