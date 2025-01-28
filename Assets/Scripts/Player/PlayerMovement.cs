using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 6f; // Default player movement speed

    Vector3 movement; // Vector to store movement direction
    Animator anim; // Animator component for controlling animations
    Rigidbody playerRigidbody; // Rigidbody component for movement physics
    PlayerShooting shooting; // Reference to shooting functionality
    int floorMask; // Layer mask for the floor
    int speedTimer; // Timer to track speed boost duration
    float camRayLength = 100f; // Length of the camera ray for aiming
    public float speedTiming; // Tracks time elapsed during speed boost

    void Start()
    {
        speedTimer = 0;
        speed = 6f;
    }

    void Update()
    {
        // If speed boost is active, update the timer
        if (speedTimer == 1)
        {
            speedTiming += Time.deltaTime;
        }

        // Reset speed and timer after boost duration ends
        if (speedTimer == 1 && speedTiming >= 15)
        {
            speedTiming = 0;
            speedTimer = 0;
            speed = 6f;
        }
    }

    void Awake()
    {
        // Initialize components and set the floor layer mask
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        shooting = GetComponentInChildren<PlayerShooting>();
    }

    void FixedUpdate()
    {
        // Get movement input
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v); // Handle player movement
        Turning(); // Handle player rotation
        Animating(h, v); // Update walking animation
    }

    void Move(float h, float v)
    {
        // Set movement direction and apply speed
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        // Rotate player towards mouse position
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(camRay, out RaycastHit floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    void Animating(float h, float v)
    {
        // Set walking animation based on movement input
        anim.SetBool("IsWalking", h != 0f || v != 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        // Handle interactions with power-ups
        if (other.gameObject.CompareTag("Power Up 1"))
        {
            other.gameObject.SetActive(false);
            Speed();
        }
        if (other.gameObject.CompareTag("Power Up 2"))
        {
            other.gameObject.SetActive(false);
            shooting.GatlingGun();
        }
        if (other.gameObject.CompareTag("Power Up 3"))
        {
            other.gameObject.SetActive(false);
            shooting.ShotGun();
        }
    }

    void Speed()
    {
        // Activate speed boost
        speed = 10;
        speedTimer = 1;
        speedTiming = 0;
    }
}
