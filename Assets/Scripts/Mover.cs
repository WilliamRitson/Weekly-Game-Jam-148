using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : Controllable
{
    [SerializeField] private float speed;

    private Rigidbody2D rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (controller == null) return;
        rig.velocity = controller.movementDirection.normalized * speed;
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
