using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldWallButton : MonoBehaviour
{

    public Animator wallButton;
    public GameObject ballBox;
    public string buttonPush;
    public string buttonUnOccupied;

    // Use this for initialization
    void Start()
    {
        //buttonUnOccupied = "Empty";
    }

    void OnTriggerEnter(Collider Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            wallButton.SetTrigger("Pressed");
            wallButton.SetBool("Lowered", true);
            ballBox.GetComponent<OpenBoxScript>().UpdateButtonActivity(buttonPush);
        }
    }

    void OnTriggerExit(Collider Player)
    {
        wallButton.SetTrigger("Released");
        wallButton.SetBool("Lowered", false);
        ballBox.GetComponent<OpenBoxScript>().UpdateButtonActivity(buttonUnOccupied);
    }
}
