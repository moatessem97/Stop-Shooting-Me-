using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController2 : MonoBehaviour {

    [SerializeField]
    private float turnSpeed, MovingTurn, JumpForce, MoveMultiplier, animSpeedMult = 1f;
    private float gravityMult = 2.5f, turning, forward;
    Rigidbody rb;
    Animator anim;
    bool grounded;
    Vector3 normal;
    BoxCollider groundCheckCol;

	void Start () {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();     
    }


    public void AnimatorGod(Vector3 move,bool jump)
    {
        if(move.magnitude > 1f)
        {
            move.Normalize();
        }
        // movement vectors and change the vector to local\
        move = transform.InverseTransformDirection(move);
        groundChecker();
        move = Vector3.ProjectOnPlane(move, normal);
        turning = Mathf.Atan2(move.x, move.z);
        forward = move.z;

        rotator();
        movement(grounded,jump);
        updateAnimator(move);
    }

    public void OnAnimatorMove()
    {
        if(grounded && Time.deltaTime > 0)
        {
            Vector3 v = (anim.deltaPosition * MoveMultiplier) / Time.deltaTime;
            v.y = rb.velocity.y;
            rb.velocity = v;
        }
    }

    private void updateAnimator(Vector3 move)
    {
        // anim parameters set
        if (!grounded)
        {
            //jump
        }
        // leg calculation based on run cycle

        if (grounded)
        {
            // jump leg parameter
            if(move.magnitude > 0)
            {
                anim.speed = animSpeedMult;
            }
            else
            {
                anim.speed = 1f;
            }

        }
        
    }

    private void groundChecker()
    {
        // set rootmotion and grounded to true of grounded  else set them to false and also declare the normals
    }
    private void rotator()
    {
        float turningAmount = Mathf.Lerp(turnSpeed, MovingTurn, forward);
        transform.Rotate(0, turning * turningAmount * Time.deltaTime, 0);
    }
    private void movement(bool isGrounded,bool jumping)
    {
        if (isGrounded)
        {
            //ground movement
            if(jumping && anim.GetCurrentAnimatorStateInfo(0).IsName("Grounded"))
            {
                rb.velocity = new Vector3(rb.velocity.x, JumpForce, rb.velocity.z);
                grounded = false;
                anim.applyRootMotion = false;

            }
        }
        else
        {
            Vector3 EGF = (Physics.gravity * gravityMult) - Physics.gravity;
            rb.AddForce(EGF);

            // grounded stuff
        }
    }

}
