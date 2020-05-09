using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D rig;
    private Controller controller;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        controller = GetComponent<Controller>();
    }

    private void FixedUpdate()
    {
        rig.velocity = controller.movementDirection * speed * Time.fixedDeltaTime;
    }
}
