using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public AbilityMeter abilityMeter;
    public AbilityMeter shapeshiftMeter;

    public void AttachTo(Shapeshifter shapeshift, Ability ability)
    {
        shapeshiftMeter.Ability = shapeshift;
        abilityMeter.Ability = ability;
    }
}
