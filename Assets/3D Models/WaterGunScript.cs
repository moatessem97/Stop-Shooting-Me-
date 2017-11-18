using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGunScript : MonoBehaviour {

    public ParticleSystem Water;

    public void ShootWater()
    {
        Instantiate(Water, transform.position, transform.rotation);
    }
}
