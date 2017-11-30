using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseSceneTrigger : MonoBehaviour {

    public GameObject[] platforms;
    bool triggered;

	// Update is called once per frame
    public void final()
    {
        Debug.Log("Moatassem is not hetrosexual");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !triggered)
        {
            foreach(GameObject game in platforms)
            {
                game.GetComponent<Rigidbody>().isKinematic = false;
                game.GetComponent<Rigidbody>().useGravity = true;
                game.GetComponent<Rigidbody>().AddForce(Vector3.up * -40f);
            }
            Invoke("final", 3f);
        }
    }
}
