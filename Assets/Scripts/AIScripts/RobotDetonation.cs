using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RAIN.Core;

public class RobotDetonation : MonoBehaviour
{
    public ParticleSystem robotExplosion;
    public GameObject Robot;
    public AudioSource chassisExplosion;
    float explosiveDamage;

	// Use this for initialization
	void Start ()
    {
        explosiveDamage = 30.0f;
	}

    void OnTriggerEnter(Collider Player)
    {
        if(Player.gameObject.tag == "Player")
        {
            robotExplosion.Play();
            chassisExplosion.Play();
            Player.GetComponent<CharacterHealth>().health -= explosiveDamage;
            Robot.GetComponentInChildren<AIRig>().AI.WorkingMemory.SetItem<bool>("isDead", true);
            Robot.GetComponentInChildren<AIRig>().enabled = false;
            Robot.GetComponent<CapsuleCollider>().enabled = false;
            Robot.GetComponent<Rigidbody>().useGravity = false;
            Robot.GetComponent<Ragdoller>().ragdolled = true;
            Robot.GetComponent<Rigidbody>().isKinematic = true;
            this.gameObject.SetActive(false);
        }
    }
}
