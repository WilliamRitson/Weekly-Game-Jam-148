using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ProjectileLauncher))]
public class Flamethrower : Ability
{
    public int numberOfProjectiles = 6;
    public float maxDisplacment = 30;
    public float sizeRangeLow = 0.0f;
    public float sizeRangeHigh = 0.8f;
    public float delayBetweenShots = 0.3f;
    public float projectileLifespan = 0.85f;
    public float aiUseRange = 2f;


    ProjectileLauncher launcher;
    private void Awake()
    {
        launcher = GetComponent<ProjectileLauncher>();
    }

    public override void ActivateAbility(Vector2 target)
    {
        StartCoroutine(LaunchOverTime(target));
    }

    IEnumerator LaunchOverTime(Vector2 target)
    {
        Vector2 towardsTarget = target - (Vector2) transform.position;
        float angleTowardsTarget = Vector2.SignedAngle(Vector2.right, towardsTarget);
        for (int i = 0; i < numberOfProjectiles; i++)
        {
            float angle = (angleTowardsTarget + Random.Range(-maxDisplacment, maxDisplacment)) * Mathf.Deg2Rad;
            Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            launcher.LaunchInDirection(dir, 1 + Random.Range(sizeRangeLow, sizeRangeHigh), projectileLifespan);
            yield return new WaitForSeconds(delayBetweenShots);
        }
    }

    public override bool ShouldUse(GameObject target)
    {
        float range = launcher.projectileVelocity * projectileLifespan;
        return (target.transform.position - transform.position).sqrMagnitude < range * range;
    }
}
