using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLev : MonoBehaviour {



void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag=="Player")
		{
			Application.LoadLevel( Application.loadedLevel + 1 );
		}
	 }
 		
	}
	

