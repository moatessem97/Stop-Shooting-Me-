using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSlotScript : MonoBehaviour
{

    public Animator entranceDoor;
    public Animator keyItemDoor;
    public GameObject podDoor;
    bool itemSlotted;
    Vector3 itemLocation;
    Quaternion itemRotation;

    // Use this for initialization
    void Start ()
    {
        itemSlotted = false;
        itemLocation = new Vector3(-175.12f, 3.3f, 112.33f);
        itemRotation = Quaternion.Euler(0, 90, 0);

    }

    void OnTriggerEnter(Collider Item)
    {
        if(Item.gameObject.tag == "Pickup")
        {
            if(Item.gameObject.name == "KeyItem" )
            {
                Item.gameObject.GetComponent<Transform>().position = itemLocation;
                Item.gameObject.GetComponent<Transform>().rotation = itemRotation;
                itemSlotted = true;
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(itemSlotted == true)
        {
            entranceDoor.SetBool("RoomComplete", true);
            keyItemDoor.SetBool("DoorButtonPushed", true);
            podDoor.SetActive(false);
            this.gameObject.SetActive(false);
        }
	}
}
