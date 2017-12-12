using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSc : MonoBehaviour {
    [SerializeField]
    public GameObject myItem;
    private bool pickit;
    public GameObject Holder;
    public bool bomb;
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
            if (myItem.name == "Bomb(Clone)")
            {
                bomb = false;
            }
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
            if (myItem.name == "Bomb(Clone)")
            {
                bomb = false;
            }
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
                if(other.name == "Bomb(Clone)")
                {
                    bomb = true;
                }
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
        
        if (myItem && myItem.name == "Bomb(Clone)")
        {
            bomb = false;
        }
        if (myItem)
        {
            myItem.GetComponent<Rigidbody>().useGravity = true;
            myItem.GetComponent<Collider>().enabled = true;
            myItem = null;
        }
        
    }
}
