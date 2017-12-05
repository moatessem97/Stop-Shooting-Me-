using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RAIN.Core;

public class WaterScript : MonoBehaviour {
    public ParticleSystem splash;

    private void Start()
    {
        Destroy(gameObject, 0.7f);
    }
    private void createSPLASH()
    {
    
    }
    private void OnParticleCollision(GameObject other)
    {
        //Instantiate(splash, coli, transform.rotation);
        if (other.GetComponent<Rigidbody>())
        {
            if (other.GetComponentInChildren<AIRig>())
            {
                other.GetComponentInChildren<AIRig>().AI.WorkingMemory.SetItem<bool>("isDead", true);
                other.GetComponentInChildren<AIRig>().enabled = false;
                other.GetComponent<CapsuleCollider>().enabled = false;
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Ragdoller>().ragdolled = true;
                other.GetComponent<Rigidbody>().isKinematic = true;
                //hit.GetComponentInChildren<Rigidbody>().AddExplosionForce(Power, grenadeOrigin, Radius, ExplosiveKick);
            }
            if (other.tag == "Player")
            {
                other.GetComponent<CharacterHealth>().health -= 0.5f;
                //dmg player
            }
        }
    }
}
