using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSc : MonoBehaviour {
    private GameObject myItem;
    private bool IsItem = false;

	void Update () {
        if (!IsItem)
        {
            return;
        }
        myItem.transform.position = gameObject.transform.position;
        myItem.transform.rotation = gameObject.transform.rotation;
        if (Input.GetButtonDown("Fire3"))
        {
            IsItem = false;
            myItem.GetComponent<Rigidbody>().useGravity = true;
            myItem.GetComponent<Collider>().enabled = true;
            myItem = null;
        }
        if (Input.GetButtonDown("Fire4"))
        {
            IsItem = false;
            myItem.GetComponent<Rigidbody>().useGravity = true;
            myItem.GetComponent<Collider>().enabled = true;
            myItem.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * 100f);
            myItem = null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (IsItem)
        {
            return;
        }
        if(other.tag == "Pickup")
        {
            if(Input.GetButtonDown("Fire2"))
            {
                IsItem = true;
                myItem = other.gameObject;
                myItem.GetComponent<Rigidbody>().useGravity = false;
                myItem.GetComponent<Collider>().enabled = false;
                myItem.transform.position = gameObject.transform.position; 
            }
        }
    }
}
