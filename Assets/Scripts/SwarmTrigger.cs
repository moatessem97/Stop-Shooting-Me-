using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmTrigger : MonoBehaviour
{

    public Animator entranceDoor;
    public GameObject podDoor;
    public GameObject leftWall;
    public GameObject rightWall;

    // Use this for initialization
    void OnTriggerExit (Collider Item)
    {
		if(Item.gameObject.tag == "Pickup")
        {
            if(Item.gameObject.name == "SwarmTrigger")
            {
                entranceDoor.SetBool("RoomComplete", true);
                podDoor.SetActive(false);
                leftWall.SetActive(false);
                rightWall.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }
	}
	
	// Update is called once per frame
	//void Update () {
		
	//}
}
