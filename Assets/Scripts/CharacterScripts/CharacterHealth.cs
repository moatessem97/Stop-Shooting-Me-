using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour {

    private Image healthBar;
    public float health;
    public float maxHealth;
	void Start ()
    {
    		if(gameObject.name == "Player 1")
        {
            healthBar = GameObject.Find("Healthbar1").GetComponent<Image>();
            maxHealth = 200f;
            health = maxHealth;
            return;
        }
        if (gameObject.name == "Player 2")
        {
            healthBar = GameObject.Find("Healthbar2").GetComponent<Image>();
            maxHealth = 200f;
            health = maxHealth;
            return;
        }
        // enemy health
    }
	
	void Update ()
    {
        healthBar.fillAmount = health / maxHealth;
        if(health <= 0)
        {
            Debug.Log("dead" + gameObject.name);
        }
	}
}
