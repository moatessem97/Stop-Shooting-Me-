using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class dinoHealth : MonoBehaviour {

    private Image healthBar;
    public float health;
    public float maxHealth;
    void Start () {
        maxHealth = 100f;
        health = maxHealth;
        healthBar = GameObject.Find("BossHealth").transform.GetChild(0).GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        healthBar.fillAmount = health / maxHealth;
        if (health <= 0)
        {
            Debug.Log(gameObject.name +" dead");
        }
    }
}
