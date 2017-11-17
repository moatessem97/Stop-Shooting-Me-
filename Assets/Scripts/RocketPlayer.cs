using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPlayer : MonoBehaviour {

	public Rigidbody rocket,rocketReal;
	public GameObject clone;
    public ParticleSystem roocket;
	public float ThrowPower = 10; //power variable determines how fast this object will be "shot out"

    public void ShootRocket()
    {

        Rigidbody clone;
        //ParticleSystem clone; //Working For Rocket

        //clone = Instantiate(rocket, transform.position, transform.rotation); //the clone variable holds our instantiate action

        //clone = Instantiate(roocket, transform.position, transform.rotation); // WORKING FOR ROCKET
        clone = Instantiate(rocketReal, transform.position, transform.rotation);


        clone.velocity = transform.TransformDirection(Vector3.forward * ThrowPower); //applies force to our prefab using the "forward" position times our throwPower variable
                                                                                     // Final setup for rocket
    }
}