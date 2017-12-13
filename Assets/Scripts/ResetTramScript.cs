using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTramScript : MonoBehaviour
{
    public Animator target;
    public GameObject tram;
    public Vector3 originalPosition;
    bool targetHit;
    int countTilReset;

    // Use this for initialization
    void Start ()
    {
        originalPosition = tram.GetComponent<Transform>().position;
        countTilReset = 0;
	}

    public void TargetBeenHit()
    {
        if (targetHit)
        {
            return;
        }
        target.SetTrigger("Pressed");
        target.SetBool("Lowered", true);
        targetHit = true;
        tram.transform.position = originalPosition;

    }

    void Update()
    {
        if(targetHit == true)
        {
            if(countTilReset == 10)
            {
                target.SetTrigger("Released");
                target.SetBool("Lowered", false);
                targetHit = false;
            }
            else
            {
                countTilReset++;
            }
        }

    }
}
