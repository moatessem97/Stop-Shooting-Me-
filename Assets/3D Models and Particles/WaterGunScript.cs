using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGunScript : MonoBehaviour {

    public GameObject Water;
    GameObject waater;
    public void ShootWater()
    {
        waater = Instantiate(Water, transform.position, transform.rotation);
        waater.transform.SetParent(gameObject.transform);
    }
}
