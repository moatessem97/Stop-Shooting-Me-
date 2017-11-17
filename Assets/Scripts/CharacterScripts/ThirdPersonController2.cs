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
    Vector3 normal,AirMove;
    //GameObject groundCheckObj;
    //BoxCollider groundCheckObjCollider;
	void Start () {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        // the 7th child HAS to be the groundchecker
        //groundCheckObj = gameObject.transform.GetChild(6).gameObject;
        //groundCheckObjCollider = groundCheckObj.GetComponent<BoxCollider>();     
    }


    public void Movement(Vector3 move,bool jump,Vector3 move2)
    {
        if(move.magnitude > 1f)
        {
            move.Normalize();
            move2.Normalize();
        }
        // movement vectors and change the vector to local space.
        move = transform.InverseTransformDirection(move);
        //groundChecker();
        getNormalToGround();
        move = Vector3.ProjectOnPlane(move, normal);
        turning = Mathf.Atan2(move.x, move.z);
        forward = move.z;

        rotator();
        DiffMovement(grounded,jump,move2);
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
        anim.SetFloat("Forward", forward, 0.1f, Time.deltaTime);
        anim.SetFloat("Turn", turning, 0.1f, Time.deltaTime);
        anim.SetBool("OnGround", grounded);
        if (!grounded)
        {
            //jump
        }
        // leg calculation based on run cycle
        float runCycle = Mathf.Repeat(anim.GetCurrentAnimatorStateInfo(0).normalizedTime , 1);
        float jumpLeg = (runCycle < 0.5f ? 1 : -1) * forward;
        if (grounded)
        {
            anim.SetFloat("JumpLeg", jumpLeg);
        }   
            if(move.magnitude > 0)
            {
                anim.speed = animSpeedMult;
            }
            else
            {
                anim.speed = 1f;
            }
        
    }

    public void groundChecker(bool isGrounded)
    {
        
        grounded = isGrounded;
        if (grounded)
        {
            anim.applyRootMotion = true;
            //getNormalToGround();
        }
        else
        {
            anim.applyRootMotion = false;
        }

    }
    private void getNormalToGround()
    {
        //if (!grounded)
        //{
        //    return;
        //}
        RaycastHit hit;
        if(Physics.Raycast(transform.position + (Vector3.up * 0.1f),Vector3.down,out hit, 0.3f))
        {
            normal = hit.normal;
        }
    }
    private void rotator()
    {
        float turningAmount = Mathf.Lerp(turnSpeed, MovingTurn, forward);
        transform.Rotate(0, turning * turningAmount * Time.deltaTime, 0);
    }
    private void DiffMovement(bool isGrounded,bool jumping,Vector3 airMove)
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

            // air controll
            //rb.AddForce(airMove*100f);
            //rb.velocity = new Vector3(rb.velocity.x + airMove.x, rb.velocity.y, rb.velocity.z + airMove.z);
            
            rb.AddForce(airMove * 34f);
            Vector3.ClampMagnitude(rb.velocity, 50f);
            rb.AddForce(EGF);
        }
    }

}
