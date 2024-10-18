using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum WeaponType { Melee, Ranged }
    public WeaponType weaponType;

    [Header("General Settings")]
    public float damage = 10f;
    public float range = 5f;
    public float fireRate = 1f;

    [Header("Ranged Weapon Settings")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float bulletLifetime = 2f;

    [Header("Melee Weapon Settings")]
    public float meleeRadius = 1f;
    public LayerMask enemyLayer;

    private float nextFireTime = 0f;


    
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;
            Attack();
        }
    }

    void Attack()
    {
        switch (weaponType)
        {
            case WeaponType.Ranged:
                FireBullet();
                break;
            case WeaponType.Melee:
                PerformMeleeAttack();
                break;
        }
    }

    void FireBullet()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.linearVelocity = firePoint.right * bulletSpeed;

            // Destroy the bullet after a certain time
            Destroy(bullet, bulletLifetime);
        }
    }

    void PerformMeleeAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, meleeRadius, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            // Assume enemy has a script with a TakeDamage(float amount) function
            enemy.GetComponent<PlaceHolderEnemy>().TakeDamage(damage);
        }
    }

    // For visualizing melee range in the editor
    private void OnDrawGizmosSelected()
    {
        if (weaponType == WeaponType.Melee)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, meleeRadius);
        }
    }
}
