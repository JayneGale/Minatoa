using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFountainAudio : MonoBehaviour
{

	// Use this for initialization
	
        AudioSource fountainAudio;
        //Play the sound on or not?
        public bool playFountain;
  
        void Start()
        {
            //Fetch the AudioSource from the GameObject
            fountainAudio = GetComponent<AudioSource>();
            fountainAudio.Stop();
            Debug.Log("playFountain is" + playFountain);
            FountainAudio(playFountain);
        }

        public void FountainAudio(bool playFountain)
        {          
            Debug.Log("FountainAudio Method has been called and playFountain is " + playFountain);

            if (playFountain == true)          
            {
                //Play the audio you attach to the AudioSource component
                fountainAudio.Play();
                Debug.Log("I am playing the fountainAudio of " + fountainAudio.name);
            }

            else
            {
                //Stop the audio
                fountainAudio.Stop();
            }
        }
  
}
