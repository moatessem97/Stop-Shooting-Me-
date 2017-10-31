using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSMThirdPersonCharacter : MonoBehaviour {

    [SerializeField]
    private float turnSpeed, movingTurnSpeed, JumpForce, runCycleOffset, movementMultiplier, animatorSpeedMultiplier = 1f, groundCheckDist = 0.5f;
    [Range(1f, 10f)][SerializeField]
    float gravityMultiplier = 2f;
    Rigidbody rb;
    Animator anim;
    bool grounded;
    float half = 0.5f;
    float turnAmount, forwardAmount, groundCheckDitO;
    Vector3 normalToGround;
    CapsuleCollider cc;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CapsuleCollider>();

        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        groundCheckDitO = groundCheckDist;
    }

    public void Movement(Vector3 movement, bool jump)
    {
        if (movement.magnitude > 1f)
        {
            movement.Normalize();
        }
        movement = transform.InverseTransformDirection(movement);
        groundChecker();
        movement = Vector3.ProjectOnPlane(movement, normalToGround);
        turnAmount = Mathf.Atan2(movement.x, movement.z);
        forwardAmount = movement.z;

        extraTurnRotation();

        if (grounded)
        {
            groundMovement(jump);
        }
        else
        {
            airborneMovement();
        }

        AnimatorUpdate(movement);
    }
    public void OnAnimatorMove()
    {
        if(grounded && Time.deltaTime > 0)
        {
            Vector3 v = (anim.deltaPosition * movementMultiplier) / Time.deltaTime;
            v.y = rb.velocity.y;
            rb.velocity = v;
        }
    }
    private void AnimatorUpdate(Vector3 move)
    {
        anim.SetFloat("Forward", forwardAmount, 0.1f, Time.deltaTime);
        anim.SetFloat("Turn", turnAmount, 0.1f, Time.deltaTime);
        anim.SetBool("OnGround", grounded);
        if (!grounded)
        {
            anim.SetFloat("Jump", rb.velocity.y);
        }
        // leg calculation based on the run cycle of the animation and one leg should pass the other at the times 0.00 and 0.50
        float runCycle = Mathf.Repeat(anim.GetCurrentAnimatorStateInfo(0).normalizedTime + runCycleOffset, 1);
        float jumpLeg = (runCycle < half ? 1 : -1) * forwardAmount;
        if (grounded)
        {
            anim.SetFloat("JumpLeg", jumpLeg);
        }
        if(grounded && move.magnitude > 0)
        {
            anim.speed = animatorSpeedMultiplier;
        }
        else
        {
            anim.speed = 1;
        }

    }

    private void groundChecker()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + (Vector3.up * 0.1f),Vector3.down,out hit, groundCheckDist))
        {
            normalToGround = hit.normal;
            grounded = true;
            anim.applyRootMotion = true;
        }
        else
        {
            grounded = false;
            normalToGround = Vector3.up;
            anim.applyRootMotion = false;
        }
    }
    private void extraTurnRotation()
    {
        float turningSpeed = Mathf.Lerp(turnSpeed, movingTurnSpeed, forwardAmount);
        transform.Rotate(0, turnAmount * turningSpeed * Time.deltaTime, 0);
    }
    private void groundMovement(bool jump)
    {
        if(jump && anim.GetCurrentAnimatorStateInfo(0).IsName("Grounded"))
        {
            rb.velocity = new Vector3(rb.velocity.x, JumpForce, rb.velocity.z);
            grounded = false;
            anim.applyRootMotion = false;
            groundCheckDist = 0.3f;
        }
    }
    private void airborneMovement()
    {
        Vector3 EGF = (Physics.gravity * gravityMultiplier) - Physics.gravity;
        rb.AddForce(EGF);

        // ????????????????????????????????
        groundCheckDist = rb.velocity.y < 0 ? groundCheckDitO : 0.03f;
    }



}
