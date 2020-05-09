using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Controller
{
    private PlayerControls controls;

    void Awake()
    {
        controls = new PlayerControls();
        controls.Gameplay.Attack.performed += (ctx) => TriggerAttack();
    }

    void Update()
    {
        movementDirection = controls.Gameplay.Move.ReadValue<Vector2>();
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }

}
