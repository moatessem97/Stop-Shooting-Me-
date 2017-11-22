using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RAIN.Core;
public class RobotTrigger : MonoBehaviour
{
    //Need Tags for Enemy and Trap for this to work
    private GameObject[] trapTiles;
    private Rigidbody[] rbs;
	// Use this for initialization
	void Start ()
    {
        trapTiles = GameObject.FindGameObjectsWithTag("Trap");
	}

    void OnTriggerEnter(Collider Enemy)
    {
        //if(Enemy.gameObject.tag == "Enemy")
        //{
        //    for(int i = 0; i < trapTiles.Length + 1; i++)
        //    {
        //        trapTiles[i].GetComponent<Rigidbody>().useGravity = true;
        //    }
        //}
        if (Enemy.tag == "Enemy")
        {
            foreach (GameObject trap in trapTiles)
            {
                trap.GetComponent<Rigidbody>().AddForce(new Vector3(0, -10, 0));
                trap.GetComponent<Rigidbody>().useGravity = true;
                if (Enemy.GetComponentInChildren<AIRig>())
                {
                    rbs = Enemy.GetComponentsInChildren<Rigidbody>();
                    Enemy.GetComponentInChildren<AIRig>().AI.WorkingMemory.SetItem<bool>("isDead", true);
                    Enemy.GetComponentInChildren<AIRig>().enabled = false;
                    Enemy.GetComponent<CapsuleCollider>().enabled = false;
                    Enemy.GetComponent<Rigidbody>().useGravity = false;
                    Enemy.GetComponent<Ragdoller>().ragdolled = true;
                    rbs = Enemy.GetComponentsInChildren<Rigidbody>();
                    foreach(Rigidbody rb in rbs)
                    {
                        rb.AddForce(new Vector3(-200f, 30f, 0f));
                    }
                    Enemy.GetComponent<Rigidbody>().isKinematic = true;
                    
                }
            }
        }
    }
}
