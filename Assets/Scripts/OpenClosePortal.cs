using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClosePortal : MonoBehaviour {

	public GameObject portalButton;
	public bool isOpening;
	Animator animator;

	void Start () 
	{
		ButtonClicker buttonClicker; 
		buttonClicker = portalButton.GetComponent<ButtonClicker>();
		buttonClicker.OnClicked += Button_OnClicked;
		animator = gameObject.GetComponent<Animator>();
		isOpening = false;
	}

	void Button_OnClicked (bool buttonState)
	{
		animator.SetBool("isOpening", buttonState);
	}
}