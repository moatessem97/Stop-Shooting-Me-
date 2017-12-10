using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardScript : MonoBehaviour
{
    public int hazardDamage;

	// Use this for initialization
	void Start ()
    {
		
	}

    void OnTriggerStay(Collider Player)
    {
        if(Player.gameObject.tag == "Player")
        {
            Player.GetComponent<CharacterHealth>().health = Player.GetComponent<CharacterHealth>().health - (hazardDamage * Time.deltaTime);
        }
    }
	
}
