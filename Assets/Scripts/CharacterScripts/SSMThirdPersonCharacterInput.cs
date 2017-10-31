using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SSMThirdPersonCharacter))]
public class SSMThirdPersonCharacterInput : MonoBehaviour {
    private SSMThirdPersonCharacter character;
    [SerializeField]
    private Transform cam;
    private Vector3 camForward, Move;
    private bool Jump, player1;
    public bool Keyboard, Controller1, Controller2;

    private void Start () {
        cam = Camera.main.transform;
        character = GetComponent<SSMThirdPersonCharacter>();
        if(gameObject.name == "Player 1")
        {
            player1 = true;
            Keyboard = true;
        }
        else if (gameObject.name == "Player 2")
        {
            player1 = false;
            Controller1 = true;
        }
	}
	
	private void Update () {
        if (Keyboard)
        {
            if (!Jump)
            {
                Jump = Input.GetButtonDown("Jump");
            }
        }
        if (Controller1)
        {
            if (!Jump)
            {
                //Jump = Input.GetButtonDown("Jump1");
                Jump = Input.GetKeyDown(KeyCode.Joystick1Button3);
            }
        }
        if (Controller2)
        {
            if (!Jump)
            {
                //Jump = Input.GetButtonDown("Jump2");
                Jump = Input.GetKeyDown(KeyCode.Joystick2Button3);
            }
        }

        controllerToggle();
	}

    private void FixedUpdate()
    {
        myMovement();
    }

    private void controllerToggle()
    {
        if (Input.GetKeyUp(KeyCode.Y))
        {
            if (!player1)
            {
                return;
            }
            if (Keyboard == true)
            {
                Keyboard = false;
                Controller2 = true;
            }
            else
            {
                Keyboard = true;
                Controller2 = false;
            }
        }
    }

    private void myMovement()
    {
        if (Keyboard)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            //if ( v != 0 || h != 0)
            //{
            //    Debug.Log("Float v " + v);
            //    Debug.Log("Float h " + h);
            //}
            if (cam != null)
            {
                camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
                Move = v * camForward + h * cam.right;
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                Move *= 0.5f;
            }
        }
        if (Controller1)
        {
            float h1 = Input.GetAxis("HorizontalJ");
            float v1 = Input.GetAxis("VerticalJ");


            if (cam != null)
            {
                camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
                Move = v1 * camForward + h1 * cam.right;
            }
        }
        if (Controller2)
        {
            float h2 = Input.GetAxis("HorizontalJ2");
            float v2 = Input.GetAxis("VerticalJ2");

            if (cam != null)
            {
                camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
                Move = v2 * camForward + h2 * cam.right;
            }
        }

        character.Movement(Move, Jump);
        Jump = false;
    }
}
