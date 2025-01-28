using UnityEngine;

public class ZomBunnyManager : MonoBehaviour
{
    public PlayerHealth playerHealth; // Reference to the player's health
    public GameObject enemy; // Enemy prefab to spawn
    public float spawnTime = 3f; // Time interval between spawns
    public int spawnAmount; // Count of spawned enemies
    public Transform[] spawnPoints; // Array of spawn locations

    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        spawnAmount = 0;
    }

    void Spawn()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        spawnAmount++;
    }
}
