using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looker : Controllable
{
    private Animator animator;
    private Controller controller;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (controller == null) return;
        var lookVector = controller.focusPoint - (Vector2)transform.position;
        var angle = Vector2.Angle(Vector2.one, lookVector);
        AnimationDirection facing;
        Debug.Log(lookVector);
        if (angle > -45 && angle <= 45)
        {
            facing = AnimationDirection.Right;
        }
        else if (angle > 45 && angle <= 135)
        {
            facing = AnimationDirection.Backward;
        }
        else
        {
            facing = AnimationDirection.Forward;
        }
        animator.SetInteger("Facing", (int) facing);
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
