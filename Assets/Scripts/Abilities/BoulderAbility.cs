using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderAbility : Ability
{
    [SerializeField] private GameObject boundingProjectile;
    [SerializeField] private float bouncingAbilityDuration;

    private ProjectileLauncher projectileLauncher;
    private GameObject initialProjectile2D;

    private void Start()
    {
        projectileLauncher = GetComponent<ProjectileLauncher>();
        initialProjectile2D = projectileLauncher.projectile;
    }

    public override bool ShouldUse(GameObject target)
    {
        return true;
    }

    protected override void ActivateAbility(Vector2 target)
    {
        StartCoroutine(UseBouncingProjectile());
    }

    public IEnumerator UseBouncingProjectile()
    {
        projectileLauncher.projectile = boundingProjectile;
        yield return new WaitForSeconds(bouncingAbilityDuration);
        projectileLauncher.projectile = initialProjectile2D;
    }
}
