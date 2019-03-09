using UnityEngine;

public class SpinOrrery : MonoBehaviour
{

	public Vector3 rotationSpeed;
	public GameObject orreryButton;
	public bool IsSpinning;

	// Use this for initialization
	void Start ()
    {
		ButtonClicker buttonClicker; 
		buttonClicker = orreryButton.GetComponent<ButtonClicker>();
		buttonClicker.OnClicked += Button_OnClicked;
	}

	void Button_OnClicked (bool buttonState)
	{
		IsSpinning = buttonState;
	}

	// Update is called once per frame
	void Update ()
    {
		if (IsSpinning)
        {
			gameObject.transform.eulerAngles += rotationSpeed;
		}
	}

}