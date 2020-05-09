using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ProjectileLauncher))]
public class VolleyAbility : Ability
{
    public int numberOfProjectiles = 8;
    public float delayBetweenShots = 0.4f;


    ProjectileLauncher launcher;
    private void Awake()
    {
        launcher = GetComponent<ProjectileLauncher>();
    }

    protected override void ActivateAbility(Vector2 target)
    {
        Debug.Log("Fire volley");
        StartCoroutine(LaunchOverTime());
    }

    IEnumerator LaunchOverTime()
    {
        for (int i = 0; i < numberOfProjectiles; i++)
        {
            float angle = Mathf.PI * 2 / numberOfProjectiles * i;
            Vector2 vec = transform.forward * Mathf.Cos(angle) + transform.right * Mathf.Sin(angle);
            Debug.Log("Fire shot at angle " + angle + " in vec " + vec);
            launcher.LaunchInDirection(vec);
            yield return new WaitForSeconds(delayBetweenShots);
        }
    }
}
