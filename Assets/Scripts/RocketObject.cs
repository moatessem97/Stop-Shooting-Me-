using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketObject : MonoBehaviour {
	public float Radius = 5.0f;
	public float Power = 10.0f;
	public float ExplosiveKick = 1.0f;

	void Start() {

		Destroy(gameObject, 3);

	}

	void  OnCollisionEnter ( Collision collision  ){

		Vector3 grenadeOrigin = transform.position;

		Collider[] colliders = Physics.OverlapSphere (grenadeOrigin, Radius); //this is saying that if any collider within the radius of our object will feel the explosion

		foreach(Collider hit in colliders){  //for loop that says if we hit any colliders, then do the following below

			if (hit.GetComponent<Rigidbody>()){

				hit.GetComponent<Rigidbody>().AddExplosionForce(Power, grenadeOrigin, Radius, ExplosiveKick); //if we hit any rigidbodies then add force based off our power, the position of the explosion object

				Destroy(gameObject);    //the radius and finally the explosive lift. Afterwards destroy the game object

			}

		}

	}
}