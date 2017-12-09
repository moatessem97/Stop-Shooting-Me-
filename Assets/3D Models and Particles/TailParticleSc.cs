using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailParticleSc : MonoBehaviour {


    private void OnParticleCollision(GameObject other)
    {
        //Instantiate(splash, coli, transform.rotation);
        if (other.GetComponent<CharacterHealth>())
        {   
            other.GetComponent<CharacterHealth>().health -= 10f;
        }   
    }
}
