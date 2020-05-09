using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Controller))]
public class ControllerDebugger : MonoBehaviour
{
    Controller cont;
    void Start()
    {
        cont = GetComponent<Controller>();
        cont.OnAttack += () => Debug.Log("attack!");
    }

    void Update()
    {
        Debug.Log("Move in direction: " +  cont.movementDirection);
    }
}
