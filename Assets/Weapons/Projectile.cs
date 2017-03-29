using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField] float projectileSpeed; // so we can set in inspector
    [SerializeField] GameObject shooter; // so we can inspect

    float damageCaused;

    public float GetLaunchSpeed()
    {
        return projectileSpeed;
    }

    public void SetDamage(float damage)
    {
        damageCaused = damage;
    }

    public void SetShooter(GameObject shooter)
    {
        this.shooter = shooter;
    }

    void OnCollisionEnter(Collision collision)
    {
        Component damagableComponent = collision.gameObject.GetComponent(typeof(IDamageable));
        if (damagableComponent && shooter.GetType() != collision.gameObject.GetType())
        {
            (damagableComponent as IDamageable).TakeDamage(damageCaused);
        }
        Destroy(gameObject, 0.01f);
    }
}
