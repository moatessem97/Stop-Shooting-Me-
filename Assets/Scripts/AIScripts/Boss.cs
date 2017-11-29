using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum States
{
    Idle,
    Jump,
    Bite,
    TailAttack
};

public class Boss : MonoBehaviour {
    private Animator anim;
    private GameObject[] players;
    private States agentState;
    public float JumpDmg, BiteDmg, TailDmg,Rate, Health, BiteThrowForce;
    private bool player1, player2;
    private float timer;
    private GameObject target;
	void Start () {
        anim = gameObject.GetComponent<Animator>();
        players = GameObject.FindGameObjectsWithTag("Player");
        setState(States.Idle);
	}
	
	void FixedUpdate ()
    {
        bossSwitch();
	}

    private void setState(States state)
    {
        agentState = state;
        switch (state)
        {
            case States.Idle:
                break;
            case States.Bite:
                break;
            case States.Jump:
                break;
            case States.TailAttack:
                break;
        }
    }
    private void bossSwitch()
    {
        switch (agentState)
        {
            case States.Idle:
                {
                    bossDecision();
                }
                break;
            case States.Bite:
                {
                    anim.SetBool("Bite", true);
                }
                break;
            case States.Jump:
                {
                    anim.SetBool("Jump", true);
                }
                break;
            case States.TailAttack:
                {
                    anim.SetBool("Tail", true);
                }
                break;
        }
    }
    public void bossJumpReset()
    {
        timer = Time.time + 1 / Rate;
        setState(States.Idle);
        anim.SetBool("Jump", false);
    }
    public void bossTailReset()
    {
        timer = Time.time + 1 / Rate;
        setState(States.Idle);
        anim.SetBool("Tail", false);
    }
    public void bossBiteReset()
    {
        timer = Time.time + 1 / Rate;
        setState(States.Idle);
        anim.SetBool("Bite", false);
    }
    public void bossJumpDamage()
    {
        foreach(GameObject player in players)
        {
            if (player.GetComponent<ThirdPersonController2>().grounded)
            {
                player.GetComponent<CharacterHealth>().health -= JumpDmg;
            }
        }
    }
    public void biteEffect()
    {
        Vector3 direction = Vector3.Normalize(target.transform.position - transform.position);
        target.GetComponent<Rigidbody>().AddForce(Vector3.up * 3000f);
        target.GetComponent<ThirdPersonController2>().grounded = false;
        target.GetComponent<Rigidbody>().AddForce((direction * BiteThrowForce) + Vector3.up* 30f);
        target = null;
        Debug.Log("hallo");
    }
    private void bossDecision()
    {
        if (Time.time > timer)
        {
            if (player1)
            {
                transform.LookAt(GameObject.Find("Player 1").transform.position);
                setState(States.Bite);
                target = GameObject.Find("Player 1");
                player1 = false;
            }
            if (player2)
            {
                transform.LookAt(GameObject.Find("Player 2").transform.position);
                setState(States.Bite);
                target = GameObject.Find("Player 1");
                player2 = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player 1")
        {
            player1 = true;
        }
        if(other.name == "Player 2")
        {
            player2 = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player 1")
        {
            player1 = false;
        }
        if (other.name == "Player 2")
        {
            player2 = false;
        }
    }

}
