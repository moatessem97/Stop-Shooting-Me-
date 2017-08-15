using UnityEngine;
using System.Collections;

public class AutoDoorScript : MonoBehaviour {

	public Animator AutoDoorAnimator;
	public Light DoorLight;
    AudioSource audiosource;
    public AudioClip open;
    public AudioClip close;


	// Use this for initialization
	void Start () 
	{
        audiosource = GetComponent<AudioSource>();
		DoorLight.color = Color.red;
		AutoDoorAnimator.SetBool ("IsOpen", false);
	}

	void OnTriggerEnter(Collider Col)
	{
		if (Col.gameObject.tag == "Player") 
		{
			AutoDoorAnimator.SetBool ("IsOpen", true);
			DoorLight.color = Color.green;
            audiosource.PlayOneShot(open);

		}
	}

	void OnTriggerExit(Collider Col)
	{
		if (Col.gameObject.tag == "Player") 
		{
			AutoDoorAnimator.SetBool ("IsOpen", false);
			DoorLight.color = Color.red;
            audiosource.PlayOneShot(close);
		}
	}
}
