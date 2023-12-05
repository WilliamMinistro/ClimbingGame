using UnityEngine;
using HutongGames.PlayMaker;

public class ClawLogic : MonoBehaviour
{
    public GameObject mainCharacter;
    public float fixedXPosition = 1.73f;  // Fixed X position
    public float initialSlideDuration = 2.0f;  // Total duration of the initial slide down
    private float slideElapsedTime = 0f;  // Elapsed time for the slide
    private float trackingSpeed = 1.6f;
    private bool startTracking = false;  // Flag to start tracking the player
    private float trackingTimer = 0f;
    private bool isSweeping = false;
    private bool isReturning = false;
    private bool isExiting = false;
    private float sweepSpeed = 8f;
    private float exitSpeed = 20f;
    private float leftBoundary = -1.8f;
    private float rightBoundary = 1.73f;
    private float upperBoundary = 10f;
    private bool didCollide = false;  // Flag to indicate collision has occurred
    private BoxCollider2D clawCollider;

    private Vector3 initialPosition;  // Initial position of the claw
    private Vector3 velocity = Vector3.zero; // For smooth damping
    public float smoothTime = 0.3f; // Time to smooth

    void Start()
    {
        initialPosition = transform.position;
        clawCollider = GetComponent<BoxCollider2D>();
        if (clawCollider != null)
        {
            clawCollider.enabled = false;  // Initially disable the collider
        }
    }

    void Update()
    {
        if (mainCharacter != null)
        {
            if (!startTracking)
            {
                slideElapsedTime += Time.deltaTime;

                float lerpFactor = slideElapsedTime / initialSlideDuration;
                transform.position = Vector3.Lerp(initialPosition, new Vector3(fixedXPosition, mainCharacter.transform.position.y + 1.0f, transform.position.z), lerpFactor);

                if (slideElapsedTime >= initialSlideDuration)
                {
                    startTracking = true;
                    slideElapsedTime = 0f;
                }
            }
            else if (!isSweeping && !isReturning && !isExiting)
            {
                trackingTimer += Time.deltaTime;

                if (trackingTimer < 4f)
                {
                    SmoothTrackPlayer();
                }
                else if (trackingTimer >= 5f)
                {
                    isSweeping = true;
                    if (clawCollider != null)
                    {
                        clawCollider.enabled = true;  // Enable the collider when sweeping starts
                    }
                }
            }
            else if (isSweeping)
            {
                if (transform.position.x > leftBoundary)
                {
                    transform.position += Vector3.left * sweepSpeed * Time.deltaTime;
                }
                else
                {
                    isSweeping = false;
                    isReturning = true;
                }
            }
            else
            {
                MoveClawBackAndUp();
                if (isReturning && !didCollide && clawCollider != null)
                {
                    clawCollider.enabled = false; // Disable collider if sweep missed
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
         {
             if (collider.gameObject == mainCharacter)
             {
                 PlayMakerFSM playMaker = mainCharacter.GetComponent<PlayMakerFSM>();
                 if (playMaker != null)
                 {
                     playMaker.enabled = false;
                 }

                 // Attach the main character to the claw
                 mainCharacter.transform.parent = transform;

                 // Position the main character at the center of the claw's hitbox
                 mainCharacter.transform.localPosition = new Vector3(0, -1f, 0);

                 // Set the flag to indicate the claw has grabbed the player
                 didCollide = true;
             }
         }

    private void MoveClawBackAndUp()
    {
        Vector3 returnPosition = new Vector3(initialPosition.x, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, returnPosition, sweepSpeed * Time.deltaTime);

        if (transform.position.x == initialPosition.x)
        {
            if (transform.position.y < upperBoundary)
            {
                transform.position += Vector3.up * exitSpeed * Time.deltaTime;
            }
            else
            {
                if (didCollide)
                {
                    mainCharacter.transform.parent = null; // Detach the main character
                }
            }
        }
    }

    private void SmoothTrackPlayer()
    {
        Vector3 trackingPosition = new Vector3(fixedXPosition, mainCharacter.transform.position.y + 1.3f, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, trackingPosition, ref velocity, smoothTime, trackingSpeed);
    }
}