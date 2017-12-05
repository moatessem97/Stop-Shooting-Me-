using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChaseSceneBossTrigger : MonoBehaviour {

    int wow;

    private void Update()
    {
        if(wow == 2)
        {
            // condition
            //SceneManager.LoadScene("Tut4");
            Invoke("wowoow", 2f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<ThirdPersonController2>().enabled = false;
            other.GetComponent<Collider>().enabled = false;
            other.GetComponent<SSMThirdPersonCharacterInput>().enabled = false;
            other.GetComponent<Rigidbody>().AddForce(new Vector3(-10000f, 2000f, 0f));
            wow++;
        }
    }

    private void wowoow()
    {
        SceneManager.LoadScene("Tut4");
    }
}
