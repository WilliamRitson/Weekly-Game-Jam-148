using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindShieldAbility : Ability
{
    public float abilityDuration;
    public ProjectileSquander projectileSquander;
    public GameObject  WindShield;

    private void Start()
    {
        if (WindShield == null)
        {
            WindShield = transform.GetChild(1).gameObject;
        }
        WindShield.SetActive(false);

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
        if (WindShield == null)
        {
            WindShield = transform.GetChild(1).gameObject;
        }

        WindShield.SetActive(true);
        AudioManager.SharedInstance().PlayWindShieldAudio();
        projectileSquander.gameObject.SetActive(true);
        yield return new WaitForSeconds(abilityDuration);
        projectileSquander.gameObject.SetActive(false);
        WindShield.SetActive(false);
    }
}
