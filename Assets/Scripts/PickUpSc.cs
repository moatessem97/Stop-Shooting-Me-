using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSc : MonoBehaviour {
    [SerializeField]
    private GameObject myItem;
    private bool pickit;
    public GameObject Holder;

    private void Update()
    {
        if (!myItem)
        {
            return;
        }
        myItem.transform.position = gameObject.transform.position;
        myItem.transform.rotation = gameObject.transform.rotation;
    }
    public void pickUPFunction(bool prim)
    {
        
        if (prim && myItem)
        {     
            myItem.GetComponent<Rigidbody>().useGravity = true;
            myItem.GetComponent<Collider>().enabled = true;
            myItem = null;
            return;
        }      
        pickit = prim;
    }
    public void Throw(bool sec)
    {
        if (sec && myItem)
        {
            
            myItem.GetComponent<Rigidbody>().useGravity = true;
            myItem.GetComponent<Collider>().enabled = true;
            myItem.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * 100f);
            //myItem.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward)*100f);
            myItem = null;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (myItem)
        {
            pickit = false;
            return;
        }
        if((other.tag == "Pickup" || other.gameObject.tag == "Player") && other.gameObject != Holder)
        {
            if(pickit)
            {
                myItem = other.gameObject;
                myItem.GetComponent<Rigidbody>().useGravity = false;
                myItem.GetComponent<Collider>().enabled = false;
                myItem.transform.position = gameObject.transform.position; 
            }
        }
        pickit = false;
    }
    private void OnDisable()
    {
        myItem = null;
    }
}
