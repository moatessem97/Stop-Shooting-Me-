using UnityEngine;
using System.Collections;

public class TeleportTutorial : MonoBehaviour {

	public GameObject teleportPoint;
//	public GameObject Player;

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player" ) {
			other.gameObject.transform.position = teleportPoint.transform.position;
		}
	}
}