using UnityEngine;
using System.Collections;

public class HellephantMovement : MonoBehaviour
{
    Transform player; // Reference to the player's position
    PlayerHealth playerHealth; // Reference to the player's health
    HellephantHealth enemyHealth; // Reference to this enemy's health
    UnityEngine.AI.NavMeshAgent nav; // NavMeshAgent for pathfinding

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player object
        playerHealth = player.GetComponent<PlayerHealth>(); // Get the PlayerHealth component
        enemyHealth = GetComponent<HellephantHealth>(); // Get this enemy's health component
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>(); // Get the NavMeshAgent component
    }

    void Update()
    {
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            nav.SetDestination(player.position); // Move towards the player
        }
        else
        {
            nav.enabled = false; // Disable navigation if either is dead
        }
    }
}
