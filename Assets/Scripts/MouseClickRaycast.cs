using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
//using ButtonClicker;

public class MouseClickRaycast : MonoBehaviour {

	public GameObject player;
	public CharacterController playerController;
	public bool buttonIsOn;
	private MouseLook mouseLook;
	private FirstPersonController rfpc;

//raycast direction
	private Ray ray;
//	private Vector3 rayStartPos;
//	private Vector3 rayDir;

//change cursor to a hand
	public bool cursorIsOver;
	public Texture2D mouseHand;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;


	void Start () 
	{
		cursorIsOver = false;
//		rayStartPos = Camera.main.transform.position;
		buttonIsOn = false;
		if (playerController != null) 
		{
			rfpc = playerController.GetComponent<FirstPersonController> ();
			if (rfpc == null)
				Debug.Log ("No RigidbodyFirstPersonController found");
		}
	}
	
	void Update ()
	{
		RaycastHit hit;
		ray = Camera.main.ScreenPointToRay (Input.mousePosition); 
//		rayStartPos = Camera.main.transform.position;
//		rayDir = Input.mousePosition;
//		Debug.DrawRay (rayStartPos, rayDir*1000.0f, Color.blue);
		if (Physics.Raycast (ray, out hit, 100.0f)) {
//			Debug.Log ("Ray is hitting the " + hit.transform.tag);
			if (hit.collider.tag == "Button") {
				cursorIsOver = true;
				CursorTexture(mouseHand, hotSpot);
				if (Input.GetMouseButtonDown(0)) 
				{
//					Debug.Log ("You clicked a " + hit.collider);
					buttonIsOn = true;
					MakeItSo (hit.collider);
				}
			}
		} else {
			cursorIsOver = false;
			CursorTexture(null, hotSpot);
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			ExitMinitoa ();
		}
	}

	public void ExitMinitoa()
	{
		Application.Quit();
	}
	
	void CursorTexture(Texture2D texture, Vector2 hotSpot)
	{
		Cursor.SetCursor(texture, hotSpot, cursorMode);
	}

	public void MakeItSo(Collider col)
	{
		col.GetComponent<ButtonClicker>().ToggleButton();
	}

}