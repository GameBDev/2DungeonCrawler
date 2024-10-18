using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    void Update()
        {
            // Get the mouse position in the world
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Calculate the direction from the object to the mouse
            Vector3 direction = mousePosition - transform.position;

            // Ensure the direction is only in the X and Y axes (2D game)
            direction.z = 0;

            // Calculate the angle to rotate towards
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Rotate the object
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
