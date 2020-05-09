using UnityEngine;
using System.Collections;
using System;

/// <summary> An abstract class representing either the player or an A.I that can control a character </summary>
public abstract class Controller : MonoBehaviour
{
    /// <summary> Trigger the controlled entity to attack </summary>
    public event Action OnAttack;

    /// <summary> The direction the controlled entities wants to move </summary>
    public Vector2 movementDirection;
    
    protected void TriggerAttack()
    {
        OnAttack?.Invoke();
    }
}
