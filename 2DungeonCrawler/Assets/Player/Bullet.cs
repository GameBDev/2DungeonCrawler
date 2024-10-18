using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;
    public float lifetime = 2f; // Time before bullet despawns if it doesn't hit anything

    void Start()
    {
        // Start a timer to destroy the bullet after a certain amount of time
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlaceHolderEnemy enemy = hitInfo.GetComponent<PlaceHolderEnemy>();
        if (enemy != null)
        {
            // Apply damage to the enemy
            enemy.TakeDamage(damage);
        }

        // Destroy the bullet on impact
        Destroy(gameObject);
    }
}
