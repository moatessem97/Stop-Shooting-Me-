using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(SSMThirdPersonCharacter))]
public class SSMThirdPersonCharacterInput : MonoBehaviour {
    private ThirdPersonController2 character;
    [SerializeField]
    private Transform cam;
    private Vector3 camForward, Move;
    private bool Jump, player1,Primary,Secondary,isRocket, isWater,isPickUp,isMelee;
    public bool Keyboard, Controller1, Controller2, Interact;
    private PickUpSc pickUpScript;
    private RocketPlayer rocketGunShootScript;
    private PickUpSc pickUpGunScript;
    private WaterGunScript myWaterGunScript;
    public GameObject CurrWeapon;
    [SerializeField]
    private float rateOfFire,FireTime;
    public bool isDead;
    // 0 for mele 1 for rocket 2 for water 3 for gravity
    private GameObject[] weaponImages;

    private void Awake()
    {
        weaponImages = new GameObject[4];
        if (gameObject.name == "Player 1")
        {
            weaponImages[0] = GameObject.Find("LightsaberImage1");
            weaponImages[1] = GameObject.Find("RocketImage1");
            weaponImages[2] = GameObject.Find("HoseImage1");
            weaponImages[3] = GameObject.Find("GravityImage1");
        }
        else if (gameObject.name == "Player 2")
        {
            weaponImages[0] = GameObject.Find("LightsaberImage");
            weaponImages[1] = GameObject.Find("RocketImage");
            weaponImages[2] = GameObject.Find("HoseImage");
            weaponImages[3] = GameObject.Find("GravityImage");
        }
        foreach(GameObject img in weaponImages)
        {
            img.SetActive(false);
        }
    }
    private void Start () {
        cam = Camera.main.transform;
        character = GetComponent<ThirdPersonController2>();
        if (gameObject.name == "Player 1")
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
            weaponImages[2].SetActive(true);
            weaponImages[1].SetActive(false);
            weaponImages[0].SetActive(false);
            weaponImages[3].SetActive(false);
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
            weaponImages[3].SetActive(true);
            weaponImages[1].SetActive(false);
            weaponImages[2].SetActive(false);
            weaponImages[0].SetActive(false);
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
            weaponImages[2].SetActive(true);
            weaponImages[1].SetActive(false);
            weaponImages[0].SetActive(false);
            weaponImages[3].SetActive(false);
            rateOfFire = 7f;
            isRocket = false;
            isPickUp = false;
            isWater = true;
            isMelee = false;
            myWaterGunScript = CurrWeapon.GetComponentInChildren<WaterGunScript>();
        }
        else if(CurrWeapon.name == "lightsaber")
        {
            Debug.Log("Lazer Sword");
            weaponImages[0].SetActive(true);
            weaponImages[1].SetActive(false);
            weaponImages[2].SetActive(false);
            weaponImages[3].SetActive(false);
            rateOfFire = 5f;
            isRocket = false;
            isPickUp = false;
            isWater = false;
            isMelee = true;
        }
        // add mele weapon too
    }
	private void Update () {
        if (isDead)
        {
            return;
        }
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
            Interact = Input.GetButton("InteractK");
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
            Interact = Input.GetButton("InteractJ");
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
            Interact = Input.GetButton("InteractJ2");
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
                myWaterGunScript.ShootWater();
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
        if (isDead)
        {
            return;
        }
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
