using UnityEngine;
using System.Collections;

public class ButtonTriggerScript : MonoBehaviour {

	Animator ButtonAnimator;
	public Animator ButtonDoorAnimator;

	// Use this for initialization
	void Start () 
	{
		ButtonAnimator = GetComponent<Animator> ();
		ButtonAnimator.SetBool ("IsPressed", false);
		ButtonDoorAnimator.SetBool ("IsOpen", false);
	}

	void OnTriggerEnter(Collider Col)
	{
		if (Col.gameObject.tag == "Resizable") 
		{
			ButtonAnimator.SetBool ("IsPressed", true);
			ButtonDoorAnimator.SetBool ("IsOpen", true);
		}
	}

	void OnTriggerExit(Collider Col)
	{
		if (Col.gameObject.tag == "Resizable") 
		{
			ButtonAnimator.SetBool ("IsPressed", false);
			ButtonDoorAnimator.SetBool ("IsOpen", false);
		}
	}
}
