using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public AbilityMeter abilityMeter;
    public AbilityMeter shapeshiftMeter;
    public Meter damageMeter;

    public void AttachTo(Shapeshifter shapeshift, Ability ability, Damagable health)
    {
        shapeshiftMeter.Ability = shapeshift;
        abilityMeter.Ability = ability;
        damageMeter.ConnectDamagable(health);
    }
}
