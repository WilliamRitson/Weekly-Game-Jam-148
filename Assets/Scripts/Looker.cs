using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looker : Controllable
{
    [SerializeField] private float saveRange;//the range where can the mouse move without changing the character direction

    private Animator animator;
    private Rigidbody2D rig;


    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (gameObject.CompareTag("Enemy"))
        {
            saveRange = 1;
        }
    }

    private void Update()
    {
        animator.SetFloat("xVelocity", rig.velocity.x);
        animator.SetFloat("yVelocity", rig.velocity.y);

        if (rig.velocity != Vector2.zero)
        {
            //if (rig.velocity.x > 0)
            //{
            //    animator.SetBool("isLeft", false);
            //    animator.SetBool("isRight", true);
            //}
            //else if (rig.velocity.x <= 0)
            //{
            //    animator.SetBool("isRight", false);
            //    animator.SetBool("isLeft", true);
            //}
            //else if (rig.velocity.y > 0)
            //{
            //    animator.SetBool("isForward", false);
            //    animator.SetBool("isBackward", true);
            //}
            //else if (rig.velocity.y <= 0)
            //{
            //    animator.SetBool("isBackward", false);
            //    animator.SetBool("isForward", true);
            //}

            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (controller == null) return;
        var lookVector = controller.focusPoint - (Vector2)transform.position;
        AnimationDirection facing;

        //print(lookVector);

        if ((lookVector.x >= 0 && lookVector.y >= 0 && lookVector.x <= saveRange) || (lookVector.x < 0 && lookVector.y >= 0 && lookVector.x >= -saveRange))
        {
            facing = AnimationDirection.Backward;
        }
        else if ((lookVector.x >= 0 && lookVector.y >= 0 && lookVector.x >= saveRange) || (lookVector.x >= 0 && lookVector.y < 0 && lookVector.x >= saveRange))
        {
            facing = AnimationDirection.Right;
        }
        else if ((lookVector.x >= 0 && lookVector.y < 0 && lookVector.x <= saveRange) || (lookVector.x < 0 && lookVector.y < 0 && lookVector.x >= -saveRange))
        {
            facing = AnimationDirection.Forward;
        }
        else if ((lookVector.x < 0 && lookVector.y > 0 && lookVector.x <= -saveRange) || (lookVector.x < 0 && lookVector.y < 0 && lookVector.x <= -saveRange))
        {
            facing = AnimationDirection.Left;
        }
        else
        {
            facing = AnimationDirection.Forward;
        }
        animator.SetInteger("Facing", (int)facing);
    }

    protected override void AddController(Controller controller)
    {
        this.controller = controller;
    }

    protected override void RemoveController(Controller controller)
    {
        this.controller = null;
    }
}
