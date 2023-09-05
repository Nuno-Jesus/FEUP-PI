using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float moveSpeed = 10f; // The speed at which the object moves
    public float leftLimit = 1; // The leftmost limit of movement
    public float rightLimit = -1; // The rightmost limit of movement

    void Update()
    {
        // Get the position of the mouse in screen space
        Vector3 mousePos = Input.mousePosition;
        
        // Convert the position from screen space to world space
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, transform.position.z - Camera.main.transform.position.z));
        
        // Restrict movement to left and right
        float clampedXPos = Mathf.Clamp(worldMousePos.x, leftLimit, rightLimit);
        Vector3 targetPos = new Vector3(clampedXPos, transform.position.y, transform.position.z);
        
        // Move the object towards the mouse position
        transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }
}
