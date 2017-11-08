using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour {

	public int WeaponSelected = 0;
	// Use this for initialization
	void Start () {
		WeaponSelect ();
		
	}
	
	// Update is called once per frame
	void Update () {

		int previousWeaponSelected = WeaponSelected;
			
		if (Input.GetAxis ("Mouse ScrollWheel") > 0f) 
		{
			if (WeaponSelected >= transform.childCount - 1)
				WeaponSelected = 0;
				
			else
			WeaponSelected++;
		}
				
		if (Input.GetAxis ("Mouse ScrollWheel") < 0f) 
		{
			if (WeaponSelected <= 0)
				WeaponSelected = transform.childCount - 1;
			else
				WeaponSelected--;
		}

			if (previousWeaponSelected !=WeaponSelected)
			{
				WeaponSelect();
			}
	}

	void WeaponSelect ()
	{
		int i = 0;
		foreach (Transform weapon in transform) 
		{
			if (i == WeaponSelected)
				weapon.gameObject.SetActive (true);
			else
				weapon.gameObject.SetActive (false);
			i++;

		}
	}
}
