using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Controller))]
public abstract class Controllable : MonoBehaviour
{
    protected Controller controller;

    public void SetController(Controller newController)
    {
        if (controller == newController)
        {
            return;
        }
        if (controller != null)
        {
            RemoveController(controller);
        }
        AddController(newController);
    }

    protected abstract void AddController(Controller controller);

    protected abstract void RemoveController(Controller controller);

    private void OnDestroy()
    {
        if (controller)
            RemoveController(controller);
    }

}
