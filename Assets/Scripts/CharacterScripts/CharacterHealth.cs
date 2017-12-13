using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CharacterHealth : MonoBehaviour {

    private Animator anim;
    private Image healthBar;
    public float health;
    public float maxHealth;
    public bool deade,deadcheck;
    [SerializeField]
    private GameObject[] faces;
    // 0 for good 1 for beatup 2 for dead
	void Start ()
    {
        if (GetComponent<Animator>())
        {
            anim = gameObject.GetComponent<Animator>();
        }
        faces = new GameObject[3];
    	if(gameObject.name == "Player 1")
        {
            healthBar = GameObject.Find("Healthbar1").GetComponent<Image>();
            maxHealth = 200f;
            health = maxHealth;
            faces[0] = GameObject.Find("PinkGood");
            faces[1] = GameObject.Find("PinkBeat");
            faces[2] = GameObject.Find("PinkDead");
            return;
        }
        if (gameObject.name == "Player 2")
        {
            healthBar = GameObject.Find("Healthbar2").GetComponent<Image>();
            maxHealth = 200f;
            health = maxHealth;
            faces[0] = GameObject.Find("BlueGood");
            faces[1] = GameObject.Find("BlueBeat");
            faces[2] = GameObject.Find("BlueDead");
            return;
        }

        faces[1].SetActive(false);
        faces[2].SetActive(false);
        // enemy health
    }
	
	void Update ()
    {
        healthBar.fillAmount = health / maxHealth;
        if(health/ maxHealth >= 0.5f)
        {
            faces[0].SetActive(true);
            faces[2].SetActive(false);
            faces[1].SetActive(false);
        }
        if(health/maxHealth < 0.5f)
        {
            faces[1].SetActive(true);
            faces[0].SetActive(false);
            faces[2].SetActive(false);
        }
        if(health <= 0)
        {
                faces[2].SetActive(true);
                faces[0].SetActive(false);
                faces[1].SetActive(false);
            Debug.Log("dead" + gameObject.name);
            if(gameObject.tag == "Player")
            {
                GetComponent<SSMThirdPersonCharacterInput>().isDead = true;
                GetComponentInChildren<WeaponSwitcher>().enabled = false;
                if (GetComponentInChildren<MeleWeaponScript>())
                {
                    GetComponentInChildren<MeleWeaponScript>().enabled = false;
                   
                }
                anim.SetBool("isDead", true);
                anim.SetLayerWeight(1, 0);
                deade = true;
                if(SceneManager.GetActiveScene().name != "BossFight")
                {
                    if(gameObject.name == "Player 1")
                    {
                        if (GameObject.FindObjectOfType<CameraFollow>())
                        {
                            GameObject.FindObjectOfType<CameraFollow>().Player1 = GameObject.Find("Player 2").transform;
                        }
                    }
                    if (gameObject.name == "Player 2")
                    {
                        if (GameObject.FindObjectOfType<CameraFollow>())
                        {
                            GameObject.FindObjectOfType<CameraFollow>().Player2 = GameObject.Find("Player 1").transform;
                        }
                    }
                }
                if(GameObject.Find("Player 1").GetComponent<CharacterHealth>().deade == true && GameObject.Find("Player 2").GetComponent<CharacterHealth>().deade == true)
                {
                    if (!deadcheck)
                    {
                        deadcheck = true;
                        Invoke("reloadLevle", 2f); 
                    }
                }
            }
        }
	}
    private void reloadLevle()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameObject.Find("LevelManager").GetComponent<PauseGame>().GaymOver.SetActive(true);
    }
}
