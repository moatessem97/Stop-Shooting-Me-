using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayersScript : MonoBehaviour
{

    public GameObject resetPosition1;
    public GameObject resetPosition2;
    Transform resetPos1;
    Transform resetPos2;

    void Start()
    {
        resetPos1 = resetPosition1.GetComponent<Transform>();
        resetPos2 = resetPosition2.GetComponent<Transform>();
    }

    void OnTriggerEnter(Collider Player)
    {
        if(Player.gameObject.tag == "Player")
        {
            if(Player.gameObject.name == "Player 1")
            {
                Player.gameObject.GetComponent<Transform>().position = resetPos1.position;
            }
            else if (Player.gameObject.name == "Player 2")
            {
                Player.gameObject.GetComponent<Transform>().position = resetPos2.position;
            }
        }
    }
}
