using UnityEngine;

public class ClawLogic : MonoBehaviour
{
    public GameObject mainCharacter;  // Reference to the main character
    public float fixedXPosition = 1.73f;  // Fixed X position
    public float initialSlideDuration = 2.0f;  // Total duration of the initial slide down
    private float slideElapsedTime = 0f;  // Elapsed time for the slide
    private float trackingSpeed = 1.6f;
    private bool startTracking = false;  // Flag to start tracking the player

    private Vector3 initialPosition;  // Initial position of the claw
    private Vector3 targetPosition;  // Target position for the initial slide

    void Start()
    {
        // Set the initial position and calculate the initial target position
        initialPosition = transform.position;
        targetPosition = new Vector3(fixedXPosition, mainCharacter.transform.position.y + 1.0f, transform.position.z);
    }

    void Update()
    {
        if (mainCharacter != null)
        {
            if (!startTracking)
            {
                // Increment elapsed time
                slideElapsedTime += Time.deltaTime;

                // Calculate the position using Lerp
                float lerpFactor = slideElapsedTime / initialSlideDuration;
                transform.position = Vector3.Lerp(initialPosition, targetPosition, lerpFactor);

                // Check if the initial slide duration is completed
                if (slideElapsedTime >= initialSlideDuration)
                {
                    startTracking = true;
                    slideElapsedTime = 0f;  // Reset the slide timer
                }
            }
            else
            {
            // Smooth tracking of the player's Y position
            Vector3 targetPosition = new Vector3(fixedXPosition, mainCharacter.transform.position.y + 1.3f, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * trackingSpeed);
            }
        }
    }
}