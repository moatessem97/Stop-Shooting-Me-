using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleTrigger : MonoBehaviour {

	public GameObject Icon;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player")
		{
			Icon.SetActive (true);
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.tag == "Player")
		{
			Icon.SetActive (false);
		}
	}
}
