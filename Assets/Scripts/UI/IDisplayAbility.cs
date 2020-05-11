using System;
using UnityEngine;

public interface IDisplayAbility
{
    Sprite Icon { get; }
    string Name { get; }
    event Action<float> OnCooldown;
}
