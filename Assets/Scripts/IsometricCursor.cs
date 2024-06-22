using UnityEngine;

public class IsometricCursor : MonoBehaviour
{
    public float gridSize = 1f;
    private Vector3 cursorPosition;

    void Update()
    {
        UpdateCursor();
    }

    void UpdateCursor()
    {
        // Get the mouse position in the world
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Since we're working in 2D, set z to 0

        // Calculate the closest grid position
        Vector3 gridPosition = CalculateGridPosition(mousePosition);

        // Move the cursor to the grid position
        transform.position = gridPosition;
    }

    Vector3 CalculateGridPosition(Vector3 position)
    {
        // Calculate the grid-aligned position
        float gridX = Mathf.Floor(position.x / gridSize) * gridSize + gridSize / 2;
        float gridY = Mathf.Floor(position.y / gridSize) * gridSize + gridSize / 2;
        
        return new Vector3(gridX, gridY, position.z);
    }
}