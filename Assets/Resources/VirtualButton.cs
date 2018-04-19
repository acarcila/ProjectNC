using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualButton : MonoBehaviour, IVirtualButtonEventHandler {

	public GameObject virtualButton;
	// Use this for initialization
	void Start () {
		virtualButton.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		
	}

	public void OnButtonPressed(VirtualButtonBehaviour vb)
	{
		Debug.Log ("pressed");

	}

	public void OnButtonReleased(VirtualButtonBehaviour vb)
	{
		Debug.Log ("released");

	}
}
