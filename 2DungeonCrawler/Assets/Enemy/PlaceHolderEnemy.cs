using UnityEngine;

public class PlaceHolderEnemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is createdpublic float health = 50f;
     public float health = 50f; 
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
