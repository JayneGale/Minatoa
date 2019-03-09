using UnityEngine;

public class ClosePortalOnExit : MonoBehaviour {
    public GameObject portalButton1;
    public GameObject portalButton2;
    public GameObject ExitPortal;
    public GameObject portal;
 //   public GameObject fountain;
 //   AudioSource portalAudio;
 //   AudioSource fountainAudio;
    Animator portalAnimator;
    public bool isOpening;

    private void Start()
    {
        portalAnimator = portal.GetComponent<Animator>();
 //       portalAudio = portal.GetComponent<AudioSource>();
 //       fountainAudio = fountain.GetComponent<AudioSource>();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            portalButton1.GetComponent<ButtonClicker>().DeactivateButton();
            portalButton2.GetComponent<ButtonClicker>().DeactivateButton();
            isOpening = false;
            portalAnimator.SetBool("isOpening", isOpening);
        }

    }
}
