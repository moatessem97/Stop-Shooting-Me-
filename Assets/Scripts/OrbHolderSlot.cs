using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbHolderSlot : MonoBehaviour
{

    public GameObject bridgeMaster;
    public GameObject proxyKey;
    Transform setOrbLocation;

    // Use this for initialization
    void Start()
    {
        setOrbLocation = this.gameObject.GetComponent<Transform>();
    }

    void OnTriggerEnter(Collider Item)
    {
        if (Item.gameObject.tag == "Pickup")
        {
            if (Item.gameObject.name == "WBKey" || Item.gameObject.name == "CKey" || Item.gameObject.name == "SKey")
            {
                Item.gameObject.GetComponent<Transform>().position = setOrbLocation.position;
                bridgeMaster.GetComponent<BridgeMasterScript>().GetKeyStateUpdate(Item.gameObject.name);
                Item.gameObject.SetActive(false);
                proxyKey.SetActive(true);
                this.gameObject.SetActive(false);
            }
        }
    }
}
