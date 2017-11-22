using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetButton : MonoBehaviour
{

    public Animator target;
    public Animator ballBox;

    void OnTriggerEnter(Collider Rocket)
    {
        if (Rocket.gameObject.tag == "Rocket")
        {
            target.SetTrigger("Pressed");
            target.SetBool("Lowered", true);
            ballBox.SetBool("Puzzle Solved", true);
        }
    }
}
