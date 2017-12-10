using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetButton : MonoBehaviour
{

    public Animator target;
    public Animator ballBox;
    bool targetHit;

    public void TargetBeenHit()
    {
        if (targetHit)
        {
            return;
        }
         target.SetTrigger("Pressed");
         target.SetBool("Lowered", true);
         ballBox.SetBool("Puzzle Solved", true);
         targetHit = true;

    }
}
