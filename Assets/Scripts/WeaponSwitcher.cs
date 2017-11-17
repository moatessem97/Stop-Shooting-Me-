using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour {

	public int WeaponSelected = 0;
    private SSMThirdPersonCharacterInput charInput;
	// Use this for initialization
	void Start () {
        charInput = transform.GetComponentInParent<SSMThirdPersonCharacterInput>();
        WeaponSelect ();
	}
	
	// Update is called once per frame
	void Update () {

		int previousWeaponSelected = WeaponSelected;
        if (charInput.Keyboard || charInput.Controller2)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f || Input.GetAxis("JoystickScroll2") > 0f)
            {
                if (WeaponSelected >= transform.childCount - 1)
                    WeaponSelected = 0;

                else
                    WeaponSelected++;
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0f || Input.GetAxis("JoystickScroll2") < 0f)
            {
                if (WeaponSelected <= 0)
                    WeaponSelected = transform.childCount - 1;
                else
                    WeaponSelected--;
            }
        }
        if(charInput.Controller1)
        {
            if (Input.GetAxis("JoystickScroll") > 0f)
            {
                if (WeaponSelected >= transform.childCount - 1)
                    WeaponSelected = 0;

                else
                    WeaponSelected++;
            }

            if (Input.GetAxis("JoystickScroll") < 0f)
            {
                if (WeaponSelected <= 0)
                    WeaponSelected = transform.childCount - 1;
                else
                    WeaponSelected--;
            }
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
            {
                weapon.gameObject.SetActive(true);
                charInput.CurrWeapon = weapon.gameObject;
                charInput.weaponInput();
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
		}
	}
}
