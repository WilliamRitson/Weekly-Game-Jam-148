using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Controller
{
    private PlayerControls controls;
    private Camera playerCamera;

    void Awake()
    {
        controls = new PlayerControls();
        controls.Gameplay.Attack.performed += (ctx) => Attack();
        playerCamera = Camera.main;
    }

    private void Attack()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        mousePos = playerCamera.ScreenToWorldPoint(mousePos);
        TriggerProjectileAttack(mousePos);
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
