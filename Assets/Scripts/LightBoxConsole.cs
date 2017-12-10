using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBoxConsole : InteractionScript
{
    public GameObject lightBoxPrefab;
    public Transform lbSpawnLoc;
    public GameObject icon;

    private void Start()
    {
        getScripts();
    }
    public override void Action()
    {
        Instantiate(lightBoxPrefab, lbSpawnLoc.position, lbSpawnLoc.rotation);
    }
    void OnTriggerEnter(Collider Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            icon.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            icon.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        Interact(other.name);
    }
}
