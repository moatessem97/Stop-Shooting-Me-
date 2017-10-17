using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotTrigger : MonoBehaviour
{
    //Need Tags for Enemy and Trap for this to work
    public GameObject[] trapTiles = new GameObject[6];

	// Use this for initialization
	void Start ()
    {
        trapTiles = GameObject.FindGameObjectsWithTag("Trap");
	}

    void OnTriggerEnter(Collider Enemy)
    {
        if(Enemy.gameObject.tag == "Enemy")
        {
            for(int i = 0; i < trapTiles.Length + 1; i++)
            {
                trapTiles[i].GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }
}
