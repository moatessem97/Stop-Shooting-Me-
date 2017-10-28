using UnityEngine;
using System.Collections;

public class Pewpew : MonoBehaviour
{
	
	public GameObject Bullet_Emitter;
	public GameObject Bullet;
	public float Bullet_Forward_Force;


	void Start ()
	{

	}


	void Update ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			
			GameObject Temporary_Bullet_Handler;
			Temporary_Bullet_Handler = Instantiate(Bullet,Bullet_Emitter.transform.position,Bullet_Emitter.transform.rotation) as GameObject;
			//Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);
			Rigidbody Temporary_RigidBody;
			Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
			Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);
			Destroy(Temporary_Bullet_Handler, 3.0f);
		}
	}
}