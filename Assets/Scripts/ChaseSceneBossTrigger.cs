using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseSceneBossTrigger : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<ThirdPersonController2>().enabled = false;
            other.GetComponent<SSMThirdPersonCharacterInput>().enabled = false;
            other.GetComponent<Rigidbody>().AddForce(new Vector3(-10000f, 2000f, 0f));
        }
    }
}
