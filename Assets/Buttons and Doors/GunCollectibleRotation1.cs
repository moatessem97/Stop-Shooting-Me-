using UnityEngine;
using System.Collections;

public class GunCollectibleRotation : MonoBehaviour {

	public float RotationSpeed;

	// Update is called once per frame
	void Update () 
	{
		transform.Rotate (Vector3.down * RotationSpeed * Time.deltaTime);
	}
}
