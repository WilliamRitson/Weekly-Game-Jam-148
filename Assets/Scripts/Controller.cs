﻿using UnityEngine;
using System.Collections;
using System;

/// <summary> An abstract class representing either the player or an A.I that can control a character </summary>
public abstract class Controller : MonoBehaviour
{
    /// <summary> Trigger the controlled entity to attack. </summary>
    public event Action OnAttack;

    /// <summary> The direction the controlled entities wants to move. </summary>
    public Vector2 movementDirection;

    /// <summary> The point the character shoud look at. </summary>
    public Vector2 focusPoint;

    public event Action<Vector2> OnLaunchProjectile;

    public event Action<Vector2> OnActivateAbility;

    public event Action<Vector2> OnShapeshift;

    private void Start()
    {
        ConnectedToControllables();
    }

    protected void ConnectedToControllables()
    {
        foreach (Controllable controllable in GetComponents<Controllable>())
        {
            controllable.SetController(this);
        }
    }

    protected void TriggerAttack()
    {
        OnAttack?.Invoke();
    }

    protected void TriggerProjectileAttack(Vector2 target)
    {
        OnLaunchProjectile?.Invoke(target);
    }

    protected void TriggerShapeshift(Vector2 target)
    {
        OnShapeshift?.Invoke(target);
    }

    protected void TriggerAbility(Vector2 target)
    {
        OnActivateAbility?.Invoke(target);
    }

}
