using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToDoorPuzzleScript : MonoBehaviour
{
    public Animator centralButton;
    public Animator exitDoor;
    public Light doorLight;
    public AudioSource room;
    public AudioClip doorOpen;
    public AudioClip doorClose;
    public AudioClip buttonPressed;
    public AudioClip buttonReleased;
    int waitPeriod;
    int buttonReset;

    bool occupied;
    bool doorOpened;

    // Use this for initialization
    void Start ()
    {
        occupied = false;
        doorOpened = false;
        waitPeriod = 0;

        if(centralButton == null || exitDoor == null)
        {
            Debug.Log("Button and Door won't Work, Animators need to be assigned for Button and/or Door.");
        }
	}

    void OnTriggerEnter(Collider wObject)
    {
        if(wObject.gameObject.tag == "Player" || wObject.gameObject.tag == "Pickup")
        {
            occupied = true;
            waitPeriod = 0;
            buttonReset = 0;
            centralButton.SetTrigger("Pressed");
            centralButton.SetBool("Lowered", true);
        }
    }

    void OnTriggerExit(Collider wObject)
    {
        if (wObject.gameObject.tag == "Player" || wObject.gameObject.tag == "Pickup")
        {
            occupied = false;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(occupied == true && doorOpened == false)
        {
            doorLight.color = Color.green;
            exitDoor.SetTrigger("Open");
            doorOpened = true;
        }
        else if(occupied == false && doorOpened == true)
        {
            if(buttonReset == 5)
            {
                centralButton.SetTrigger("Released");
                centralButton.SetBool("Lowered", false);
                buttonReset = 0;
            }
            else
            {
                buttonReset++;
            }
            if(waitPeriod == 10)
            {
                exitDoor.SetTrigger("Close");
                doorOpened = false;
                waitPeriod = 0;
                doorLight.color = Color.red;
            }
            else
            {
                waitPeriod++;
            }
        }
	}
}
