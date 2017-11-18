using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleTrigger : InteractionScript {

	public GameObject Icon;
    private Animator anim;

    public override void Action()
    {
        anim.SetBool("AllKeysCollected", true);
    }

    private void Start()
    {
        anim = GetComponentInParent<Animator>();
        getScripts();
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
    private void OnTriggerStay(Collider col)
    {
        Interact(col.name);
    }
}
