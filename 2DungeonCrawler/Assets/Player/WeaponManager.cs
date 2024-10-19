using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Transform weaponHolder;
    public GameObject defaultFistWeapon;

    private GameObject[] equippedWeapons = new GameObject[2];
    private int activeWeaponIndex = 0;

    void Start()
    {
        // Equip default fists if no weapon is equipped
        EquipWeapon(defaultFistWeapon, 0);
    }

    void Update()
    {
        // Switch weapons with number keys or scroll wheel
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SwitchWeapon(0);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            SwitchWeapon(1);

        // Drop weapon with 'Q' key
        if (Input.GetKeyDown(KeyCode.Q))
            DropWeapon(activeWeaponIndex);
    }

    public void PickUpWeapon(GameObject weaponPrefab)
    {
        // Find an empty slot in equipped weapons
        int slotIndex = GetEmptyWeaponSlot();
        if (slotIndex != -1)
        {
            EquipWeapon(weaponPrefab, slotIndex);
        }
        else
        {
            Debug.Log("Both weapon slots are full!");
        }
    }

    private void EquipWeapon(GameObject weaponPrefab, int slotIndex)
    {
        // Destroy the current weapon in that slot
        if (equippedWeapons[slotIndex] != null)
        {
            Destroy(equippedWeapons[slotIndex]);
        }

        // Instantiate the new weapon
        GameObject newWeapon = Instantiate(weaponPrefab, weaponHolder.position, weaponHolder.rotation, weaponHolder);
        equippedWeapons[slotIndex] = newWeapon;

        // If this is the active weapon, switch to it
        if (slotIndex == activeWeaponIndex)
        {
            newWeapon.SetActive(true);
        }
        else
        {
            newWeapon.SetActive(false);
        }
    }

    private void SwitchWeapon(int newIndex)
    {
        if (newIndex < 0 || newIndex >= equippedWeapons.Length || equippedWeapons[newIndex] == null)
            return;

        equippedWeapons[activeWeaponIndex].SetActive(false);
        activeWeaponIndex = newIndex;
        equippedWeapons[activeWeaponIndex].SetActive(true);
    }

    private void DropWeapon(int slotIndex)
    {
        if (equippedWeapons[slotIndex] != null)
        {
            // Instantiate a dropped weapon prefab in the world
            GameObject droppedWeapon = Instantiate(equippedWeapons[slotIndex], weaponHolder.position, weaponHolder.rotation);
            droppedWeapon.AddComponent<BoxCollider2D>(); // Add collision to the dropped weapon
            droppedWeapon.AddComponent<Rigidbody2D>().gravityScale = 1; // Make it fall to the ground

            Destroy(equippedWeapons[slotIndex]);
            equippedWeapons[slotIndex] = null;

            // Switch to fists if the dropped weapon was active
            if (slotIndex == activeWeaponIndex)
            {
                EquipWeapon(defaultFistWeapon, activeWeaponIndex);
            }
        }
    }

    private int GetEmptyWeaponSlot()
    {
        for (int i = 0; i < equippedWeapons.Length; i++)
        {
            if (equippedWeapons[i] == null)
                return i;
        }
        return -1;
    }
}
