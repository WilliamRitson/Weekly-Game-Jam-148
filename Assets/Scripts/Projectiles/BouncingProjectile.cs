using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingProjectile : Projectile2D
{
    [SerializeField] private int initialHealth;
    [SerializeField] private int projectileHealthAffectNum;//num of health is gonna be lost by hitting a small projectile
    [SerializeField] private int wallHealthAffectNum;//num of health is gonna be lost by hitting a wall
    [SerializeField] private int targetHealthAffectNum;//num of health is gonna be lost by hitting the target (entity)


    private float currentHealth;
    private Vector2 startVelocity;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        currentHealth = initialHealth;
        startVelocity = rig.velocity;
    }

    private void Update()
    {
        if (rig.velocity == Vector2.zero)
        {
            Destroy(gameObject);
        }
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("proj colide with" + col.gameObject);

        if (collision.collider.TryGetComponent(out Damagable damagable))
        {
            damagable.TakeDamage(damage, damageType);
            currentHealth -= targetHealthAffectNum;
            if (currentHealth > 0)
            {
                rig.velocity = -1 * startVelocity;//let the projectile go the opposit side which came from
            }
        }
        else if (collision.gameObject.CompareTag("Projectile"))
        {
            currentHealth -= projectileHealthAffectNum;
        }
        else if (collision.gameObject.CompareTag("BouncingProjectile"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            print("Wall");
            currentHealth -= wallHealthAffectNum;
            if (currentHealth > 0)
            {
                rig.velocity = -1 * startVelocity;//let the projectile go the opposit side which came from
            }
        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
