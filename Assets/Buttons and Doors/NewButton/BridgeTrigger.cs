﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeTrigger : MonoBehaviour
{
    public Animator bridge;

    void OnTriggerEnter(Collider Player)
    {
        if(Player.gameObject.tag == "Player")
        {
            if (Input.GetButtonDown("Use"))
            {
                bridge.SetBool("Activated", true);
            }
        }
    }
}
