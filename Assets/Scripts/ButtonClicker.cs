using UnityEngine;

public class ButtonClicker : MonoBehaviour {

	public GameObject buttonToPress;
	public bool buttonIsOn;
	MeshRenderer meshRenderer;
	public Texture buttonOn;
	public Texture buttonOff;
	Animator buttonAnimator;
    AudioSource buttonSounds;
    AudioClip buttonClick;

	public delegate void clickAction(bool buttonState);
	public event clickAction OnClicked;

	void Start () 
	{
		meshRenderer = GetComponent<MeshRenderer> ();
		meshRenderer.material.SetTexture ("_MainTex", buttonOff);
		buttonAnimator = buttonToPress.GetComponent<Animator>();
        buttonSounds = buttonToPress.GetComponent<AudioSource>();
        buttonClick = buttonSounds.clip;
    }

	public void ActivateButton()
	{
		buttonIsOn = true;	
		RefreshButton();
	}

	public void DeactivateButton()
	{
		buttonIsOn = false;
		RefreshButton();
	}

	public void ToggleButton()
	{
		buttonIsOn = !buttonIsOn;
		Debug.Log ("ButtonIsOn is " + buttonIsOn);
		RefreshButton();
	}

	public void RefreshButton()
	{
		buttonAnimator.SetTrigger ("ButtonPress");
		meshRenderer.material.SetTexture ("_MainTex", buttonIsOn ? buttonOn : buttonOff);
		if (OnClicked != null) 
		{
            buttonSounds.PlayOneShot(buttonClick);
            Debug.Log("Playing Button Audio now");
            OnClicked(buttonIsOn);
		} 
	}
}