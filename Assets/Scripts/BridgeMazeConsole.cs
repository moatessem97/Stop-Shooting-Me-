using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeMazeConsole : InteractionScript {

    public GameObject bridge;
    public GameObject icon;
    public string consoleOrder;

    private void Start()
    {
        getScripts();
    }
    public override void Action()
    {
        bridge.GetComponent<BridgeMazeMaster>().ReceiveRequest(consoleOrder);
    }
    void OnTriggerEnter(Collider Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            icon.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            icon.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        Interact(other.name);
    }
}
