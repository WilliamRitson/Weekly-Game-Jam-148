using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindShieldAbility : Ability
{
   [SerializeField] private float abilityDuration;
   [SerializeField] private ProjectileSquander projectileSquander;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool ShouldUse(GameObject target)
    {
        throw new System.NotImplementedException();
    }

    protected override void ActivateAbility(Vector2 target)
    {
        print("Activated");
        StartCoroutine(DeactivateAbility());
    }

    public IEnumerator DeactivateAbility()
    {
        projectileSquander.gameObject.SetActive(true);
        yield return new WaitForSeconds(abilityDuration);
        projectileSquander.gameObject.SetActive(false);
    }
}
