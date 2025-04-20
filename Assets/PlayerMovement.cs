using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player

    private void Update()
    {
        // Initialize movement vector
        Vector3 movement = Vector3.zero;

        // WASD controls
        if (Input.GetKey(KeyCode.W)) // Front (forward along Z-axis)
        {
            movement += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.A)) // Left (left along X-axis)
        {
            movement += Vector3.left;
        }
        if (Input.GetKey(KeyCode.S)) // Down (backward along Z-axis)
        {
            movement += Vector3.back;
        }
        if (Input.GetKey(KeyCode.D)) // Right (right along X-axis)
        {
            movement += Vector3.right;
        }

        // Normalize movement vector to ensure consistent speed when moving diagonally
        if (movement != Vector3.zero)
        {
            movement.Normalize();
        }

        // Apply movement
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        // Optional: Rotate player to face the movement direction
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(movement),
                Time.deltaTime * 10f
            );
        }
    }
}
