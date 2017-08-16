using UnityEngine;
using System.Collections;

public class MK2Door : MonoBehaviour 
{
	public Animator animator;

	public string triggerEnter;
	public string triggerExit;

	public Light lightcolor;
    AudioSource audiosource;
    public AudioClip open;
    public AudioClip close;


    void Start()
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
		if (col.gameObject.tag == "Player" || col.gameObject.tag == "Pickup")
			

			if (triggerEnter != null) 
		    {
				animator.SetTrigger (triggerEnter);
			    lightcolor.color = Color.green;
                audiosource.PlayOneShot(open);
            }





	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "Player" || col.gameObject.tag == "Pickup")


		
		if (triggerExit != null) 
		{
			animator.SetTrigger (triggerExit);
			lightcolor.color = Color.red;
            audiosource.PlayOneShot(close);
            }


			
	}
}
