using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth; // Reference to the player's health
    public float restartDelay = 5f; // Delay before restarting the game

    Animator anim; // Animator component for triggering game over animation
    public HiScoreManager hiScore; // Reference to the high score manager
    float restartTimer; // Timer to track delay before restart

    void Awake()
    {
        anim = GetComponent<Animator>(); // Initialize the animator component
    }

    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            hiScore.SetHiScore(); // Update high score if applicable

            anim.SetTrigger("GameOver"); // Trigger game over animation

            restartTimer += Time.deltaTime; // Increment the restart timer

            if (restartTimer >= restartDelay)
            {
                Application.LoadLevel(Application.loadedLevel); // Restart the current level
            }
        }
    }
}
