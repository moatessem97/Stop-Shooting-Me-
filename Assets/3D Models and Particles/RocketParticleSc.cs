using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RAIN.Core;
public class RocketParticleSc : MonoBehaviour {
    public float Radius = 5.0f;
    public float Power = 10.0f;
    public float ExplosiveKick = 1.0f;
    public ParticleSystem Boom;
    private ParticleSystem clone;
    void Start()
    {

        Destroy(gameObject, 5);
        
    }
    void createBOOM()
    {
        Instantiate(Boom, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    void AIHit(Collider lol,Vector3 wow)
    {
        Rigidbody[] rbs;
        rbs = lol.GetComponentsInChildren<Rigidbody>();
        lol.GetComponentInChildren<AIRig>().AI.WorkingMemory.SetItem<bool>("isDead", true);
        lol.GetComponentInChildren<AIRig>().enabled = false;
        lol.GetComponent<CapsuleCollider>().enabled = false;
        lol.GetComponent<Rigidbody>().useGravity = false;
        lol.GetComponent<Ragdoller>().ragdolled = true;
        lol.GetComponent<Rigidbody>().isKinematic = true;
        foreach (Rigidbody rb in rbs)
        {
            rb.AddExplosionForce(Power, wow, Radius, ExplosiveKick);
        }
    }
    void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.name);
        Vector3 grenadeOrigin = transform.position;
        Collider[] colliders = Physics.OverlapSphere(grenadeOrigin, Radius); //this is saying that if any collider within the radius of our object will feel the explosion
        foreach (Collider hit in colliders)
        {
            //for loop that says if we hit any colliders, then do the following below
            if (hit.GetComponent<Rigidbody>())
            {
                // AI stuff
                if (hit.GetComponentInChildren<AIRig>())
                {
                    AIHit(hit, grenadeOrigin);
                }
                if (hit.GetComponent<CharacterHealth>())
                {
                    hit.GetComponent<CharacterHealth>().health -= 10;
                }
                //if we hit any rigidbodies then add force based off our power, the position of the explosion object
                hit.GetComponent<Rigidbody>().AddExplosionForce(Power, grenadeOrigin, Radius, ExplosiveKick);


            }

            createBOOM();
            //Destroy(gameObject);    //the radius and finally the explosive lift. Afterwards destroy the game object

        }
    }

}
