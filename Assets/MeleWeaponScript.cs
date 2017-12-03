using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RAIN.Core;

public class MeleWeaponScript : MonoBehaviour {
    private SSMThirdPersonCharacterInput inputManager;
    private Animator anim;
    private void Awake()
    {
        anim = gameObject.GetComponentInParent<Animator>();
    }
    private void Start()
    {
        inputManager = gameObject.GetComponentInParent<SSMThirdPersonCharacterInput>();
    }

    void Update () {
		if(inputManager.gameObject.name == "Player 1" && inputManager.Keyboard == true)
        {
            anim.SetBool("isMele", Input.GetButton("Fire1M"));
        }
        else if (inputManager.gameObject.name == "Player 1" && inputManager.Controller2 == true)
        {
            anim.SetBool("isMele", Input.GetButton("Fire1J2"));

        }
        if(inputManager.gameObject.name == "Player 2")
        {
            anim.SetBool("isMele", Input.GetButton("Fire1J"));
        }
	}
    private void OnDisable()
    {
        anim.SetBool("isMele",false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInChildren<AIRig>())
        {
            other.GetComponentInChildren<AIRig>().AI.WorkingMemory.SetItem<bool>("isDead", true);
            other.GetComponentInChildren<AIRig>().enabled = false;
            other.GetComponent<CapsuleCollider>().enabled = false;
            other.GetComponent<Rigidbody>().useGravity = false;
            other.GetComponent<Ragdoller>().ragdolled = true;
            other.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
