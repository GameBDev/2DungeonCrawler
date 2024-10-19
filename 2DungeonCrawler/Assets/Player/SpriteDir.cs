using UnityEngine;

public class SpriteDir : MonoBehaviour
{
public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;
    
    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Get mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;  // Ignore Z axis for 2D game
        
        // Get direction vector from player to mouse
        Vector3 direction = (mousePosition - transform.position).normalized;
        
        // Determine the direction (up, down, left, right)
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            // Horizontal
            if (direction.x > 0)
            {
                spriteRenderer.sprite = rightSprite;  // Right
            }
            else
            {
                spriteRenderer.sprite = leftSprite;  // Left
            }
        }
        else
        {
            // Vertical
            if (direction.y > 0)
            {
                spriteRenderer.sprite = upSprite;  // Up
            }
            else
            {
                spriteRenderer.sprite = downSprite;  // Down
            }
        }
    }
}
