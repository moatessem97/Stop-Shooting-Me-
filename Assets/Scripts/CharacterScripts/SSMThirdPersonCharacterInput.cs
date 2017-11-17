using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(SSMThirdPersonCharacter))]
public class SSMThirdPersonCharacterInput : MonoBehaviour {
    private ThirdPersonController2 character;
    [SerializeField]
    private Transform cam;
    private Vector3 camForward, Move;
    private bool Jump, player1,Primary,Secondary,isRocket,isWater,isPickUp,isMelee;
    public bool Keyboard, Controller1, Controller2;
    private PickUpSc pickUpScript;
    private RocketPlayer rocketGunShootScript;
    private PickUpSc pickUpGunScript;
    // water gun script here
    public GameObject CurrWeapon;
    [SerializeField]
    private float rateOfFire,FireTime;

    // weapon number is based on each weapon 
    private void Start () {
        cam = Camera.main.transform;
        character = GetComponent<ThirdPersonController2>();
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
	public void weaponInput()
    {
        if(CurrWeapon.name == "Rocket")
        {
            Debug.Log("RocketGun");
            rateOfFire = 1f;
            isRocket = true;
            isPickUp = false;
            isWater = false;
            isMelee = false;
            rocketGunShootScript = CurrWeapon.GetComponentInChildren<RocketPlayer>();
        }
        else if (CurrWeapon.name == "Pistol27")
        {
            Debug.Log("pick up gun");
            rateOfFire = 2f;
            isRocket = false;
            isPickUp = true;
            isWater = false;
            isMelee = false;
            pickUpGunScript = CurrWeapon.GetComponentInChildren<PickUpSc>();
        }
        else if (CurrWeapon.name == "Sniper")
        {
            Debug.Log("Water Hose");
            rateOfFire = 7f;
            isRocket = false;
            isPickUp = false;
            isWater = true;
            isMelee = false;
        }
        // add mele weapon too
    }
	private void Update () {
        buttonInputs();
       
	}
    private void buttonInputs()
    {
        if (Keyboard)
        {
            if (!Jump)
            {
                Jump = Input.GetButtonDown("Jump");
            }
            Primary = Input.GetButton("Fire1M");
            Secondary = Input.GetButton("Fire2M");
        }
        if (Controller1)
        {
            if (!Jump)
            {
                Jump = Input.GetButtonDown("Jump1");
                //  Jump = Input.GetKeyDown(KeyCode.Joystick1Button0);
            }
            Primary = Input.GetButton("Fire1J");
            Secondary = Input.GetButton("Fire2J");
            //Primary = Input.GetKeyDown(KeyCode.Joystick1Button2);
            //Secondary = Input.GetKeyDown(KeyCode.Joystick1Button1);
        }
        if (Controller2)
        {
            if (!Jump)
            {
                Jump = Input.GetButtonDown("Jump2");
                //  Jump = Input.GetKeyDown(KeyCode.Joystick2Button0);
            }
            Primary = Input.GetButton("Fire1J2");
            Secondary = Input.GetButton("Fire2J2");
            //Primary = Input.GetKeyDown(KeyCode.Joystick2Button2);
            //Secondary = Input.GetKeyDown(KeyCode.Joystick2Button1);
        }
        if (Primary && Time.time > FireTime)
        {
            FireTime = Time.time + 1 / rateOfFire;
            if (isRocket)
            {
                rocketGunShootScript.ShootRocket();
            }
            if (isMelee)
            {

            }
            if (isWater)
            {

            }
            if (isPickUp)
            {
                pickUpGunScript.Throw(Primary);
            }
        }
        if (Secondary && Time.time > FireTime)
        {
            FireTime = Time.time + 1 / rateOfFire;
            if (isMelee)
            {

            }
            if (isWater)
            {

            }
            if (isPickUp)
            {
                pickUpGunScript.pickUPFunction(Secondary);
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

        character.Movement(Move, Jump,Move);
        Jump = false;
    }
}
