using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePhysicsLayers : MonoBehaviour {

    private GameObject[] objects;
	void Start () {
        objects = GameObject.FindGameObjectsWithTag("Pickup");
        Debug.Log(objects.Length);
        foreach (GameObject obj in objects)
        {
            obj.layer = LayerMask.NameToLayer("PickupObj");
            Debug.Log("Layer Changed");
        }
        Debug.Log("gaaaa");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
