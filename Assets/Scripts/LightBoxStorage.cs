using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBoxStorage : MonoBehaviour
{
    public GameObject MasterLBDetector;
    public Light towerLight;
    public string storageIdentifier;

	void OnTriggerEnter (Collider box)
    {
		if(box.gameObject.name.Contains("LightBox"))
        {
            MasterLBDetector.GetComponent<LightBoxDetection>().UpdateBoxPlacementState(storageIdentifier, "Present");
            towerLight.color = Color.green;
        }
	}

    void OnTriggerExit(Collider box)
    {
        if (box.gameObject.name.Contains("LightBox"))
        {
            MasterLBDetector.GetComponent<LightBoxDetection>().UpdateBoxPlacementState(storageIdentifier, "Missing");
            towerLight.color = Color.red;
        }
    }
}
