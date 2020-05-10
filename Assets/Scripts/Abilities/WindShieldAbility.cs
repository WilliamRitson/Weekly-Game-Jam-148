using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindShieldAbility : Ability
{
   [SerializeField] private float abilityDuration;
   [SerializeField] private ProjectileSquander projectileSquander;

    public override bool ShouldUse(GameObject target)
    {
        return true;
    }

    protected override void ActivateAbility(Vector2 target)
    {
        StartCoroutine(DeactivateAbility());
    }

    public IEnumerator DeactivateAbility()
    {
        projectileSquander.gameObject.SetActive(true);
        yield return new WaitForSeconds(abilityDuration);
        projectileSquander.gameObject.SetActive(false);
    }
}
