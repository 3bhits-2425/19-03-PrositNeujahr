using UnityEngine;

public class Cam : MonoBehaviour
{
    private float timer = 0f; // Timer to track the delay
    private bool shouldRotate = false; // Flag to start rotation
    private float rotationDuration = 3f; // Duration of the rotation (in seconds)
    private float elapsedTime = 0f; // Tracks time during the rotation

    private Quaternion initialRotation; // Initial rotation of the camera
    private Quaternion targetRotation; // Target rotation of the camera

    void Start()
    {
        initialRotation = Quaternion.Euler(-7.5f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        targetRotation = Quaternion.Euler(-50f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        transform.rotation = initialRotation;
    }

    void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Check if 10 seconds have passed and rotation hasn't started yet
        if (timer >= 10f && !shouldRotate)
        {
            shouldRotate = true; // Start rotation
        }

        // If rotation should happen
        if (shouldRotate)
        {
            // Increment elapsed time during rotation
            elapsedTime += Time.deltaTime;

            // Smoothly interpolate rotation over the course of rotationDuration
            transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, elapsedTime / rotationDuration);

            // Stop rotating once the duration is reached
            if (elapsedTime >= rotationDuration)
            {
                shouldRotate = false; // Stop further updates
            }
        }
    }
}
