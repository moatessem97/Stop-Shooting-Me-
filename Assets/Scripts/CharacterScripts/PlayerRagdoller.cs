using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRagdoller : MonoBehaviour
{

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
                    disableScripts();
                    anim.enabled = false;
                    setKinematic(true);
                    state = RagdollState.ragdolled;
                    
                }
            }
        }
    }
    enum RagdollState
    {
        animated,
        ragdolled, 
    }
    RagdollState state = RagdollState.animated;
    Animator anim;

    void setKinematic(bool newValue)
    {
        Component[] components = GetComponentsInChildren(typeof(Collider));
        foreach (Component c in components)
        {
            (c as Collider).enabled = newValue;
        }
        Debug.Log("setkin00");
    }
    void Start()
    {
        setKinematic(false);
        Component[] components = GetComponentsInChildren(typeof(Transform));
        anim = GetComponentInParent<Animator>();
        Debug.Log("WHUWHUWHUT");
    }
    void disableScripts()
    {
        if (GetComponentInParent<ThirdPersonController2>())
        {
            GetComponentInParent<ThirdPersonController2>().enabled = false;
        }
        if (GetComponentInParent<SSMThirdPersonCharacterInput>())
        {
            GetComponentInParent<SSMThirdPersonCharacterInput>().enabled = false;
        }
        if (GetComponentInChildren<WeaponSwitcher>().enabled)
        {
            GetComponentInChildren<WeaponSwitcher>().enabled = false;
        }
        if (GetComponentInParent<CapsuleCollider>().enabled)
        {
            GetComponentInParent<CapsuleCollider>().enabled = false;
        }
        
    }
}
