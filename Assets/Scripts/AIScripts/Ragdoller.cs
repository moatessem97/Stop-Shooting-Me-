using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoller : MonoBehaviour {

    public bool ragdolled
    {
        get
        {
            return state != RagdollState.animated;
        }
        set
        {
            if (value == true)
            {
                if (state == RagdollState.animated)
                {
                    setKinematic(false);
                    anim.enabled = false;
                    state = RagdollState.ragdolled;
                }
            }
        } 
    }

    enum RagdollState
    {
        animated,
        ragdolled,
        //blendToAnim  
    }

    RagdollState state = RagdollState.animated;

    //public float ragdollToMecanimBlendTime = 0.5f;
    //float mecanimToGetUpTransitionTime = 0.05f;

    //float ragdollingEndTime = -100;

    //Declare a class that will hold useful information for each body part
    public class BodyPart
    {
        public Transform transform;
        public Vector3 storedPosition;
        public Quaternion storedRotation;
    }

    Vector3 ragdolledHipPosition, ragdolledHeadPosition, ragdolledFeetPosition;

    //List<BodyPart> bodyParts = new List<BodyPart>();

    Animator anim;

    void setKinematic(bool newValue)
    {
        Component[] components = GetComponentsInChildren(typeof(Rigidbody));


        foreach (Component c in components)
        {
            (c as Rigidbody).isKinematic = newValue;
        }
    }
    void Start () {
        setKinematic(true);

        Component[] components = GetComponentsInChildren(typeof(Transform));

        //For each of the transforms, create a BodyPart instance and store the transform 
        //foreach (Component c in components)
        //{
        //    BodyPart bodyPart = new BodyPart();
        //    bodyPart.transform = c as Transform;
        //    bodyParts.Add(bodyPart);
        //}

        anim = GetComponent<Animator>();
    }

}
