using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : InteractionScript {

	public GameObject Icon;
    private Animator anim;
    private bool isLoaded;
    public Rigidbody cannonRb;
    private PickUpSc p1, p2;
    public GameObject ammo;
    private ParticleSystem ps;
    public GameObject pos;
    private AudioSource aud;
    public override void Action()
    {
        Debug.Log("Hello");
    }

    private void Start()
    {
        anim = GetComponentInParent<Animator>();
        getScripts();
        ps = gameObject.GetComponentInChildren<ParticleSystem>();
        aud = GetComponent<AudioSource>();
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
        if (col.name == "Player 1")
        {
            if (player1.Interact)
            {
                // Debug.Log("player1 pressed");
                if (isLoaded)
                {
                    isLoaded = false;
                    ps.Play();
                    aud.Play();
                    Instantiate(ammo, pos.transform.position, transform.rotation);
                    cannonRb.isKinematic = false;
                    cannonRb.useGravity = true;
                    cannonRb.AddForce(transform.forward * -1300f);
                }
                if (!isLoaded)
                {
                    if (col.GetComponentInChildren<PickUpSc>())
                    {
                        if (col.GetComponentInChildren<PickUpSc>().bomb == true)
                        {
                            col.GetComponentInChildren<PickUpSc>().bomb = false;
                            Destroy(col.GetComponentInChildren<PickUpSc>().myItem);
                            col.GetComponentInChildren<PickUpSc>().myItem = null;
                            isLoaded = true;
                        }
                    }
                }

            }
        }
        if (col.name == "Player 2")
        {
            if (player2.Interact)
            {
                // Debug.Log("player2 pressed");
                if (isLoaded)
                {
                    isLoaded = false;
                    ps.Play();
                    aud.Play();
                    Instantiate(ammo, pos.transform.position, transform.rotation);
                    cannonRb.isKinematic = false;
                    cannonRb.useGravity = true;
                    cannonRb.AddForce(transform.forward * -1300f);

                }
                if (!isLoaded)
                {
                    if (col.GetComponentInChildren<PickUpSc>())
                    {
                        if (col.GetComponentInChildren<PickUpSc>().bomb == true)
                        {
                            col.GetComponentInChildren<PickUpSc>().bomb = false;
                            Destroy(col.GetComponentInChildren<PickUpSc>().myItem);
                            col.GetComponentInChildren<PickUpSc>().myItem = null;
                            isLoaded = true;
                        }
                    }
                }
            }
        }
    }
}
