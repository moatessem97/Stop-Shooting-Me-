using UnityEngine;
using System.Collections;

public class ButtonMovement : MonoBehaviour {
	
	public Animator animator;

	public string triggerEnter;
	public string triggerExit;

    AudioSource audiosource;
    public AudioClip open;
    public AudioClip close;
    // Use this for initialization
    void Start () 
	{
        audiosource = GetComponent<AudioSource>();
        if (animator == null) 
		{
			animator = GetComponent<Animator> ();
			if (animator == null) 
			{
				Debug.LogError ("ADD ANIMATOR PLZ TY",gameObject);
			}
		}
	
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player" || col.gameObject.tag == "Resizable")
			

		if (triggerEnter != null) 
		{
			animator.SetTrigger (triggerEnter);
            audiosource.PlayOneShot(open);
            }
			
	}

	void OnTriggerExit(Collider col)
	{
		if(col.gameObject.tag == "Player" || col.gameObject.tag == "Resizable")


		if (triggerExit != null) 
		{
			animator.SetTrigger (triggerExit);
            audiosource.PlayOneShot(close);
            }
			
	}
}
