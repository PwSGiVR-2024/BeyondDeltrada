using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector3 targetPosition;
    private bool isMoving = false;

    public float footOffset = -0.5f; // Vertical offset for the player's feet

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleMouseClick();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void HandleMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Get the mouse position in the world
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // Since we are working in 2D, set z to 0

            // Add the offset to the target position to account for the player's feet
            Vector3 footPosition = new Vector3(mousePosition.x, mousePosition.y + footOffset, mousePosition.z);

            // Set the target position
            targetPosition = footPosition;
            isMoving = true;
        }
    }

    void MovePlayer()
    {
        if (isMoving)
        {
            // Move the player towards the target position
            Vector2 newPosition = Vector2.MoveTowards(rb.position, targetPosition, moveSpeed * Time.fixedDeltaTime);
            rb.MovePosition(newPosition);

            // If the player reaches the target position, stop moving
            if (Vector3.Distance(rb.position, targetPosition) < 0.1f)
            {
                isMoving = false;
            }
        }
    }
}