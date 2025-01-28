using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public PlayerHealth playerHealth; // Reference to the player's health
    public GameObject powerUp_1; // First type of power-up
    public GameObject powerUp_2; // Second type of power-up
    public GameObject powerUp_3; // Third type of power-up
    public float spawnTimer; // Timer to track spawn intervals
    public float randomizer; // Random value to control spawn logic
    public int rnd; // Random value placeholder (unused)
    public int powerUp; // Type of power-up to spawn (unused)
    public int spawnPoint; // Selected spawn point index
    public Transform spawnPoint_1; // First spawn point
    public Transform spawnPoint_2; // Second spawn point
    public Transform spawnPoint_3; // Third spawn point
    public Transform spawnPoint_4; // Fourth spawn point

    void Start()
    {
        spawnTimer = 0;
        randomizer = 0;
        powerUp = 0;
        spawnPoint = 0;
    }

    void Update()
    {
        spawnTimer += Time.deltaTime; // Increment the spawn timer
        randomizer = Random.Range(1, 40); // Generate a random value
        spawnPoint = Random.Range(1, 4); // Select a random spawn point

        if (playerHealth.currentHealth > 0 && spawnTimer >= 15 && randomizer == 10 && spawnPoint == 1)
        {
            SpawnPowerUp(powerUp_1, spawnPoint_1);
        }
        if (playerHealth.currentHealth > 0 && spawnTimer >= 15 && randomizer == 10 && spawnPoint == 2)
        {
            SpawnPowerUp(powerUp_1, spawnPoint_2);
        }
        if (playerHealth.currentHealth > 0 && spawnTimer >= 15 && randomizer == 10 && spawnPoint == 3)
        {
            SpawnPowerUp(powerUp_1, spawnPoint_3);
        }
        if (playerHealth.currentHealth > 0 && spawnTimer >= 15 && randomizer == 20 && spawnPoint == 1)
        {
            SpawnPowerUp(powerUp_2, spawnPoint_1);
        }
        if (playerHealth.currentHealth > 0 && spawnTimer >= 15 && randomizer == 20 && spawnPoint == 2)
        {
            SpawnPowerUp(powerUp_2, spawnPoint_2);
        }
        if (playerHealth.currentHealth > 0 && spawnTimer >= 15 && randomizer == 20 && spawnPoint == 3)
        {
            SpawnPowerUp(powerUp_2, spawnPoint_3);
        }
        if (playerHealth.currentHealth > 0 && spawnTimer >= 15 && randomizer == 30 && spawnPoint == 1)
        {
            SpawnPowerUp(powerUp_3, spawnPoint_1);
        }
        if (playerHealth.currentHealth > 0 && spawnTimer >= 15 && randomizer == 30 && spawnPoint == 2)
        {
            SpawnPowerUp(powerUp_3, spawnPoint_2);
        }
        if (playerHealth.currentHealth > 0 && spawnTimer >= 15 && randomizer == 30 && spawnPoint == 3)
        {
            SpawnPowerUp(powerUp_3, spawnPoint_3);
        }
    }

    void SpawnPowerUp(GameObject powerUp, Transform spawnPoint)
    {
        spawnTimer = 0; // Reset the spawn timer
        Instantiate(powerUp, spawnPoint.position, spawnPoint.rotation); // Spawn the power-up
    }
}
