using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterAbilities : MonoBehaviour
{
    //Both Players Need a PickUp Object
    //Both Need a Gun Object and sight to use ability
    //Input Manager needs Switch input variable
    //IMPORTANT: SCRIPT NEEDS TO BE DUPLICATED AND INDIVIDUAL PLAYERS INPUTS MUST BE SUBSTITUTED IN.

    //Fire Variables
    public Rigidbody rocket;
    public GameObject clone;
    public float ThrowPower = 10; //power variable determines how fast this object will be "shot out"

    //PickUp Variables
    private GameObject myItem;
    private bool IsItem = false;

    //TriggerSwitch
    //bool cycleAbility = false;

    int currentWeaponID;
    //weaponIconOne
    //weaponIconTwo
    //weaponIconThree

    void Start()
    {
        currentWeaponID = 0;
    }

    // Use this for initialization
    private void OnTriggerStay(Collider other)
    {
        if (IsItem)
        {
            return;
        }
        if (other.tag == "Pickup" || other.gameObject.name == "PlayerA")
        {
            if (Input.GetButtonDown("Fire2"))
            {
                IsItem = true;
                myItem = other.gameObject;
                myItem.GetComponent<Rigidbody>().useGravity = false;
                myItem.GetComponent<Collider>().enabled = false;
                myItem.transform.position = gameObject.transform.position;
            }
        }
    }

    void PickUp()
    {
        if (!IsItem)
        {
            return;
        }
        myItem.transform.position = gameObject.transform.position;
        myItem.transform.rotation = gameObject.transform.rotation;
        if (Input.GetButtonDown("Fire3"))
        {
            IsItem = false;
            myItem.GetComponent<Rigidbody>().useGravity = true;
            myItem.GetComponent<Collider>().enabled = true;
            myItem = null;
        }
        if (Input.GetButtonDown("Fire4"))
        {
            IsItem = false;
            myItem.GetComponent<Rigidbody>().useGravity = true;
            myItem.GetComponent<Collider>().enabled = true;
            myItem.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * 100f);
            myItem = null;
        }
    }

    void CycleWeapon()
    {
        if (currentWeaponID >= 3)
        {
            currentWeaponID = 0;
        }
        else
        {
            currentWeaponID++;
        }
    }

    void UseCurrentWeapon()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (currentWeaponID == 0)
            {
                Rigidbody clone;

                clone = Instantiate(rocket, transform.position, transform.rotation); //the clone variable holds our instantiate action
                clone.velocity = transform.TransformDirection(Vector3.forward * ThrowPower); //applies force to our prefab using the "forward" position times our throwPower variable
            }
            else if(currentWeaponID == 1)
            {
                //Balloon Weapon
            }
            else if (currentWeaponID == 2)
            {
                //Hose Weapon
            }
        }
    }

    // Update is called once per frame
    void Update ()
    {
        PickUp();

        if(Input.GetButtonDown("Switch"))
        {
            CycleWeapon();
        }

        UseCurrentWeapon();
    }
}
