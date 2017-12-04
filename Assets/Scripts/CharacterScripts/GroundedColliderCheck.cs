using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedColliderCheck : MonoBehaviour {

    public bool grounded;
    [SerializeField]
    private ThirdPersonController2 pc;
    public bool CheckStop;
    private void Start()
    {
        CheckStop = false;
        pc = GetComponentInParent<ThirdPersonController2>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (!CheckStop)
        {
            grounded = true;
            pc.groundChecker(grounded);
            return;
        }
            Invoke("TurnBoolTrue", 0.8f);
    }
    private void OnTriggerExit(Collider other)
    {
        grounded = false;
        pc.groundChecker(grounded);
    }
    public void TurnBoolTrue()
    {
        CheckStop = false;
    }
}
