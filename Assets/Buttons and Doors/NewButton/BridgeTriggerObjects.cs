using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeTriggerObjects : MonoBehaviour
{
    public Animator bridge;

    void OnTriggerEnter(Collider Player)
    {
        if(Player.gameObject.tag == "Pickup")
        {
            bridge.SetBool("Activated", true);
        }
    }
}
