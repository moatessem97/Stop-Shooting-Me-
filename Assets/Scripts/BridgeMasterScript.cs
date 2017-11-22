using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeMasterScript : MonoBehaviour
{
    public Animator bridge;
    public GameObject bridgeS;
    public GameObject bridgeWall;
    bool acquiredWBKey;
    bool acquiredCKey;
    bool acquiredSkey;
    bool bridgeActivated;

	// Use this for initialization
	void Start ()
    {
        acquiredWBKey = false;
        acquiredCKey = false;
        acquiredSkey = false;
        bridgeActivated = false;
    }

    public void GetKeyStateUpdate(string KeyName)
    {
        if(KeyName == "WBKey")
        {
            acquiredWBKey = true;
        }
        else if (KeyName == "CKey")
        {
            acquiredCKey = true;
        }
        else if (KeyName == "SKey")
        {
            acquiredSkey = true;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(bridgeActivated == false)
        {
            if(acquiredWBKey == true && acquiredCKey == true && acquiredSkey == true)
            {
                bridge.SetBool("AllKeysCollected", true);
                bridgeWall.SetActive(false);
                bridgeS.GetComponent<BoxCollider>().enabled = true;
                bridgeActivated = true;
            }
        }
	}
}
