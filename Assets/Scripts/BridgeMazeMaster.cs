using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeMazeMaster : MonoBehaviour {

    public Animator mazeBridge;
    public Transform idleLocation;
    public GameObject bridge;
    string activeOrder;
    string currentPosition;

    // Use this for initialization
    void Start ()
    {
        activeOrder = null;
        currentPosition = "Idle";
	}

    public void ReceiveRequest(string consoleCommand)
    {
        if(activeOrder == null && consoleCommand != currentPosition)
        {
            activeOrder = consoleCommand;
        }
    }

    void ProcessRequest(string command)
    {
        if(currentPosition == "Idle")
        {
            mazeBridge.SetBool(command, true);
            currentPosition = command;
            activeOrder = null;
        }
        else
        {
            mazeBridge.SetBool(currentPosition, false);
            currentPosition = "Idle";
        }
    }
     
	
	// Update is called once per frame
	void Update ()
    {
		if(activeOrder != null)
        {
            ProcessRequest(activeOrder);
        }
	}
}
