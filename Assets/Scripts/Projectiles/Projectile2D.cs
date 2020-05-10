using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Projectile2D : MonoBehaviour
{
    public bool isTargetingPlayer;
    public float projectileVelocity;
    public int damage = 1;
    public Element damageType;
    private void OnCollisionEnter2D(Collision2D col) {
        Debug.Log("proj colide with" + col.gameObject);
        Damagable damagable = col.collider.GetComponent<Damagable>();
        if (damagable) {
            damagable.TakeDamage(damage, damageType);
        }
        Destroy(gameObject);
    }
}
