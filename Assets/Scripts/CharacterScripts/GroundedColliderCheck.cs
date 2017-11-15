using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedColliderCheck : MonoBehaviour {

    public bool grounded;
    [SerializeField]
    private ThirdPersonController2 pc;

    private void Start()
    {

        pc = GetComponentInParent<ThirdPersonController2>();
    }
    private void OnTriggerStay(Collider other)
    {
        grounded = true;
        pc.groundChecker(grounded);
        Debug.Log("grounded");
    }
    private void OnTriggerExit(Collider other)
    {
        grounded = false;
        pc.groundChecker(grounded);
    }

}
