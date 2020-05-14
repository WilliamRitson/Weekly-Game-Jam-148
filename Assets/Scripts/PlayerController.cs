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
        controls.Gameplay.Shapeshift.performed += (ctx) => Shapeshift();
        controls.Gameplay.Ability.performed += (ctx) => Ability();
        playerCamera = Camera.main;
    }

    private void Attack()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        mousePos = playerCamera.ScreenToWorldPoint(mousePos);
        TriggerProjectileAttack(mousePos);
    }

    private void Shapeshift()
    {
        TriggerShapeshift(focusPoint);
    }

    private void Ability()
    {
        TriggerAbility(focusPoint);
    }

    void Update()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        movementDirection = controls.Gameplay.Move.ReadValue<Vector2>();
        focusPoint = playerCamera.ScreenToWorldPoint(mousePos);
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 3);
    }
}
