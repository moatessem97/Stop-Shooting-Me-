using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour {

    private Animator anim;
    private Image healthBar;
    public float health;
    public float maxHealth;
	void Start ()
    {
        if (GetComponent<Animator>())
        {
            anim = gameObject.GetComponent<Animator>();
        }
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
            if(gameObject.tag == "Player")
            {
                GetComponent<SSMThirdPersonCharacterInput>().isDead = true;
                GetComponentInChildren<WeaponSwitcher>().enabled = false;
                GetComponentInChildren<MeleWeaponScript>().enabled = false;
                anim.SetBool("isDead", true);
                anim.SetLayerWeight(1, 0);
            }
        }
	}
}
