using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeTrigger : InteractionScript
{
    public Animator bridge;
    public GameObject icon;
    private void Start()
    {
        getScripts();
    }
    public override void Action()
    {
        bridge.SetBool("Activated", true);
    }
    void OnTriggerEnter(Collider Player)
    {
        if(Player.gameObject.tag == "Player")
        {
            icon.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            icon.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        Interact(other.name);
    }
}
