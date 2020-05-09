using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float initialSpeed;
    [SerializeField] private float maxMomentum;
    [SerializeField] private float timeToInreaseSpeed;


    private Rigidbody2D rig;
    private Controller controller;
    private float deltaTimeCounter;
    private float momentum;

    private void Start()
    {
        momentum = 1;
        deltaTimeCounter = 0;
        rig = GetComponent<Rigidbody2D>();
        controller = GetComponent<Controller>();
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
        rig.velocity = controller.movementDirection.normalized * initialSpeed * momentum;
    }
}
