using UnityEngine;

public class OpenClosePortal : MonoBehaviour
{

    public GameObject portalButton;
	public GameObject portal;
    public GameObject portalDoor;
    public GameObject fountainWithAudio;
    public GameObject player;
    AudioSource fountainAudio;
    AudioSource portalAudio;
    Animator portalAnimator;
    float portalDoorPos;
    float playerPos;
    bool insideRoom;


    void Start () 
	{
		ButtonClicker buttonClicker; 
		buttonClicker = portalButton.GetComponent<ButtonClicker>();
		buttonClicker.OnClicked += Button_OnClicked;
		portalAnimator = portal.GetComponent<Animator>();
        fountainAudio = fountainWithAudio.GetComponent<AudioSource>();
        portalAudio = portal.GetComponent<AudioSource>();
 //       isOpening = portalAnimator.GetBool("isOpening");
        portalDoorPos = gameObject.transform.position.x;
        playerPos = player.transform.position.x;
    }

    void Button_OnClicked (bool buttonState)
	{
        Debug.Log("ButtonState is " + buttonState);
        portalAnimator.SetBool("isOpening", buttonState);
        playerPos = player.transform.position.x;
        portalDoorPos = portalDoor.transform.position.x;
        if (playerPos < portalDoorPos)
        {
            insideRoom = true;
        }
        else
        {
            insideRoom = false;
        }
        //      Invoke("TogglePortalAudio", 3.0f);
        //       isOpening = portalAnimator.GetBool("isOpening");
        if (buttonState)
        {
            portalAudio.Play();
            fountainAudio.Play();
        }
        if (!buttonState && insideRoom)
        {
            portalAudio.Stop();
            fountainAudio.Play();
        }
        if (!buttonState && !insideRoom)
        {
            fountainAudio.Stop();
            portalAudio.Play();
        }
    }
}