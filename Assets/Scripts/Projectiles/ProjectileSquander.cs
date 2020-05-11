using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSquander : MonoBehaviour
{
    [SerializeField] private GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        if (parent == null)
        {
            parent = transform.parent.gameObject;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            Projectile2D projectile2D = collision.GetComponent<Projectile2D>();
            if (projectile2D.isTargetingPlayer && parent.CompareTag("Player"))
            {
                projectile2D.GetAffectedBySquander();
            }
            else if (!projectile2D.isTargetingPlayer && parent.CompareTag("Enemy"))
            {
                projectile2D.GetAffectedBySquander();
            }
        }
    }
}
