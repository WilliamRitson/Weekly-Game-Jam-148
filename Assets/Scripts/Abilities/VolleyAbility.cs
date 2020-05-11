using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ProjectileLauncher))]
public class VolleyAbility : Ability
{
    public int numberOfProjectiles = 8;
    public float delayBetweenShots = 0.1f;


    ProjectileLauncher launcher;
    private void Awake()
    {
        launcher = GetComponent<ProjectileLauncher>();
    }

    public override void ActivateAbility(Vector2 target)
    {
        StartCoroutine(LaunchOverTime());
    }

    IEnumerator LaunchOverTime()
    {
        for (int i = 0; i < numberOfProjectiles; i++)
        {
            float angle = Mathf.PI * 2 / numberOfProjectiles * i;
            Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            launcher.LaunchInDirection(dir);
            yield return new WaitForSeconds(delayBetweenShots);
        }
    }

    public override bool ShouldUse(GameObject target)
    {
        return true;
    }
}
