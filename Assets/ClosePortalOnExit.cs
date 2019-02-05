using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePortalOnExit : MonoBehaviour {
    public GameObject portalButton1;
    public GameObject portalButton2;
            
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            portalButton1.GetComponent<ButtonClicker>().DeactivateButton();
            portalButton2.GetComponent<ButtonClicker>().DeactivateButton();
        }
    }

}
