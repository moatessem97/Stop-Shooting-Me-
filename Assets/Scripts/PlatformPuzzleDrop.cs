using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPuzzleDrop : MonoBehaviour
{

	void OnCollisionEnter(Collision Player)
    {
        if(Player.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;
            //this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
