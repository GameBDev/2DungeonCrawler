using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GameObject weaponPrefab; // Weapon to be picked up

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            WeaponManager weaponManager = other.GetComponent<WeaponManager>();
            Debug.Log("found player");

            if (weaponManager != null)
            {
                weaponManager.PickUpWeapon(weaponPrefab);
                Destroy(gameObject); // Remove the pickup after it's collected
                Debug.Log("PickupScript");
            }
        }
    }
}
