using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomatedDoors : MonoBehaviour {

    public Animator areaDoor;
    public AudioClip doorOpen;

    bool doorOpened;
    bool beginReset;
    int doorReset;

    // Use this for initialization
    void Start()
    {
        doorOpened = false;
        beginReset = false;
    }

    void OnTriggerEnter(Collider wObject)
    {
        if(wObject.gameObject.tag == "Player")
        {
            if (doorOpened == false)
            {
                areaDoor.SetTrigger("Open");
                doorOpened = true;
            }
        }
    }

    void OnTriggerExit(Collider wObject)
    {
        if (wObject.gameObject.tag == "Player")
        {
            beginReset = true;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(beginReset == true)
        {
            if(doorReset == 15)
            {
                areaDoor.SetTrigger("Close");
                beginReset = false;
                doorOpened = false;
            }
            else
            {
                doorReset++;
            }
        }	
	}
}
