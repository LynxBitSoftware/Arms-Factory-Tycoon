using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Speed at which the camera moves
    public float moveSpeed = 10f;

    // Minimum and maximum x-coordinates of the slideable area
    public float minX = -10f;
    public float maxX = 10f;

    // Update is called once per frame
    void Update()
    {
        // Get the distance that the finger has moved since the last frame
        float fingerMovement = Input.GetAxis("Horizontal");

        // Calculate the amount to move the camera
        float movementAmount = fingerMovement * moveSpeed * Time.deltaTime;

        // Calculate the new position of the camera
        float newX = transform.position.x + movementAmount;

        // Clamp the x-coordinate of the camera to the slideable area
        newX = Mathf.Clamp(newX, minX, maxX);

        // Move the camera
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
