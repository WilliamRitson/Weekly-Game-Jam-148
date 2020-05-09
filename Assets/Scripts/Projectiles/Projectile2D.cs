using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile2D : MonoBehaviour
{
    public float speed = 5.0f;
    public int damage = 1;
    public Element damageType;
    
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.right.normalized * speed;
    }

     void OnTriggerEnter2D(Collider2D col) {
        Damagable damagable = col.GetComponent<Damagable>();
        if (damagable) {
            damagable.TakeDamage(damage, damageType);
        }
        Destroy(gameObject);
    }
}
