using UnityEngine;

public class ZomBearManager : MonoBehaviour
{
    public PlayerHealth playerHealth; // Reference to the player's health
    public GameObject enemy; // Enemy prefab to spawn
    public float spawnTime = 3f; // Time interval between spawns
    public int spawnAmount; // Count of spawned enemies
    public Transform[] spawnPoints; // Array of spawn locations

    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime); // Schedule periodic spawns
        spawnAmount = 0;
    }

    void Spawn()
    {
        if (playerHealth.currentHealth <= 0f) return; // Skip spawning if player is dead

        int spawnPointIndex = Random.Range(0, spawnPoints.Length); // Select a random spawn point
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation); // Spawn the enemy
        spawnAmount++; // Increment the spawn counter
    }
}
