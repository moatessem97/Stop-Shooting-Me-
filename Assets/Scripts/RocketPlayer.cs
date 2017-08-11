using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPlayer : MonoBehaviour {

	public Rigidbody rocket;
	public GameObject clone;
	public float ThrowPower = 10; //power variable determines how fast this object will be "shot out"

	void Update() {

		if (Input.GetButtonDown("Fire1")) {

			Rigidbody clone; 

			clone = Instantiate(rocket, transform.position, transform.rotation); //the clone variable holds our instantiate action

			clone.velocity = transform.TransformDirection(Vector3.forward * ThrowPower); //applies force to our prefab using the "forward" position times our throwPower variable

		}

	}
}