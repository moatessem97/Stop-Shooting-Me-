using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{

    public Animator button;
    public Animator door;
    public bool ActiveOnce;

    void OnTriggerEnter(Collider Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            button.SetTrigger("Pressed");
            button.SetBool("Lowered", true);
            door.SetBool("DoorButtonPushed", true);
        }
    }

    void OnTriggerExit(Collider Player)
    {
        if (ActiveOnce == false)
        {
            button.SetTrigger("Released");
            door.SetBool("DoorButtonPushed", false);
        }
    }
}
