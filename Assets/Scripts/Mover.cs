using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : Controllable
{
    [SerializeField] private float initialSpeed;
    [SerializeField] private float maxMomentum;
    [SerializeField] private float timeToInreaseSpeed;


    private Rigidbody2D rig;
    private float deltaTimeCounter;
    private float momentum;

    private void Start()
    {
        momentum = 1;
        deltaTimeCounter = 0;
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        deltaTimeCounter += Time.deltaTime;

        if (controller.movementDirection == Vector2.zero)
        {
            momentum = 1;
        }

        if (momentum < maxMomentum && deltaTimeCounter >= timeToInreaseSpeed)
        {
            deltaTimeCounter = 0;
            momentum += .1f;
        }
        print(momentum + " momentum");
        print(rig.velocity);
    }

    private void FixedUpdate()
    {
        if (controller == null) return;
        rig.velocity = controller.movementDirection.normalized * initialSpeed * momentum;
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
