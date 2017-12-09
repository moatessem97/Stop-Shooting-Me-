using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractionScript : MonoBehaviour {

    protected SSMThirdPersonCharacterInput player1,player2;

    //private void Start()
    //{
    //    player1 = GameObject.Find("Player 1").GetComponent<SSMThirdPersonCharacterInput>();
    //    player2 = GameObject.Find("Player 2").GetComponent<SSMThirdPersonCharacterInput>();
    //}

    protected void getScripts()
    {
        player1 = GameObject.Find("Player 1").GetComponent<SSMThirdPersonCharacterInput>();
        player2 = GameObject.Find("Player 2").GetComponent<SSMThirdPersonCharacterInput>();
    }
    protected void Interact(string playername)
    {
       // Debug.Log("wow");
        if (playername == "Player 1")
        {
            if (player1.Interact)
            {
                Action();
               // Debug.Log("player1 pressed");
            }
        }
        if (playername == "Player 2")
        {
            if (player2.Interact)
            {
               // Debug.Log("player2 pressed");
                Action();
            }
        }
    }

    public virtual void Action()
    {
    }

}
