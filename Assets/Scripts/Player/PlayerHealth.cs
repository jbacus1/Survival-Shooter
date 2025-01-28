// This script manages the player's health, damage effects, and death behavior in Unity.

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // Public variables accessible from the Unity editor
    public int startingHealth = 100;           // Initial health of the player
    public int currentHealth;                 // Current health of the player
    public Slider healthSlider;               // UI slider to display health
    public Image damageImage;                 // Flash effect for damage feedback
    public AudioClip deathClip;               // Audio clip played on death
    public float flashSpeed = 5f;             // Speed of the damage flash fade
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f); // Damage flash color

    // Private variables
    private Animator anim;                    // Reference to the animator component
    private AudioSource playerAudio;          // Reference to the audio source
    private PlayerMovement playerMovement;    // Reference to the player's movement script
    private PlayerShooting playerShooting;    // Reference to the player's shooting script
    private bool isDead;                      // Whether the player is dead
    private bool damaged;                     // Whether the player has recently taken damage

    void Awake()
    {
        // Initialize component references
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        playerShooting = GetComponentInChildren<PlayerShooting>();

        // Set initial health
        currentHealth = startingHealth;
    }

    void Update()
    {
        // Update the damage image color based on whether the player was recently damaged
        if (damaged)
        {
            damageImage.color = flashColour; // Show the flash color when damaged
        }
        else
        {
            // Gradually fade the damage image back to transparent
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        // Reset the damaged flag for the next frame
        damaged = false;
    }

    public void TakeDamage(int amount)
    {
        damaged = true; // Mark the player as damaged

        // Reduce damage amount (e.g., scaling for balancing purposes)
        amount /= 10;

        // Subtract the damage amount from the current health
        currentHealth -= amount;

        // Update the health slider to reflect the new health value
        healthSlider.value = currentHealth;

        // Play the damage audio clip
        playerAudio.Play();

        // Check if the player's health is zero and trigger death if not already dead
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true; // Mark the player as dead

        // Disable shooting effects
        playerShooting.DisableEffects();

        // Trigger the death animation
        anim.SetTrigger("Die");

        // Play the death audio clip
        playerAudio.clip = deathClip;
        playerAudio.Play();

        // Disable player movement and shooting scripts
        playerMovement.enabled = false;
        playerShooting.enabled = false;
    }

    public void RestartLevel()
    {
        // Reload the first scene (index 0)
        SceneManager.LoadScene(0);
    }
}
