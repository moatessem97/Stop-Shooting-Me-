using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Level1DoorScript : MonoBehaviour {

    public Animator pRoomDoor;
    //public GameObject doorTrigger;

    int playersInRoom;
    bool player1Entered;
    bool player2Entered;

	// Use this for initialization
	void Start ()
    {
        playersInRoom = 0;
        player1Entered = false;
        player2Entered = false;
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider player)
    {
		if(player.gameObject.tag == "Player")
        {
            if(player.gameObject.name == "Player 1" && player1Entered == false)
            {
                player1Entered = true;
                playersInRoom++;
            }
            else if (player.gameObject.name == "Player 2" && player2Entered == false)
            {
                player2Entered = true;
                playersInRoom++;
            }
            else if( playersInRoom == 2)
            {
                pRoomDoor.SetTrigger("PlayersEntered");
                this.gameObject.SetActive(false);
            }
        }
	}
}
