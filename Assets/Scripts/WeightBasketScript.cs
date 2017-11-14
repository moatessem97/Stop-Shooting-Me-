using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightBasketScript : MonoBehaviour {

    public float totalWeight;
    public Animator pRoomDoor;
    public Animator tubeDoor;
	
	void OnTriggerEnter (Collider ball)
    {
        if(ball.gameObject.tag == "Pickup")
        {
            totalWeight += ball.gameObject.GetComponent<Rigidbody>().mass;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(totalWeight >= 120)
        {
            pRoomDoor.SetBool("RoomComplete", true);
        }
	}
}
