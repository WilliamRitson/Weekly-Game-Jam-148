using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindShieldAbility : Ability
{
    public float abilityDuration;
    public ProjectileSquander projectileSquander;

    private void Start()
    {
        if (projectileSquander == null)
        {
            projectileSquander = transform.GetChild(0).GetComponent<ProjectileSquander>();
        }
    }

    public override bool ShouldUse(GameObject target)
    {
        return true;
    }

    public override void ActivateAbility(Vector2 target)
    {
        StartCoroutine(DeactivateAbility());
    }

    public IEnumerator DeactivateAbility()
    {
        AudioManager.SharedInstance().PlayWindShieldAudio();
        projectileSquander.gameObject.SetActive(true);
        yield return new WaitForSeconds(abilityDuration);
        projectileSquander.gameObject.SetActive(false);
    }
}
