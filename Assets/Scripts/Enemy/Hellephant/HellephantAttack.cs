using UnityEngine;
using System.Collections;
using System;

public class HellephantAttack : MonoBehaviour
{
    // Variables
    public float timeBetweenAttacks = 0.5f; // Time interval between attacks
    public int attackDamage = 10; // Damage dealt per attack

    Animator anim; // Animator component for attack animations
    GameObject player; // Reference to the player
    PlayerHealth playerHealth; // Player's health component
    HellephantHealth enemyHealth; // Hellephant's health component
    GameObject enemyManager; // Reference to the enemy manager
    HellephantManager EMS; // Hellephant Manager script
    bool playerInRange; // Whether the player is in attack range
    int niceAttackDamage; // Placeholder for adjusted damage (unused)
    public float rawAttackDamage; // Base raw attack damage
    float timer; // Timer to track attack intervals

    void Awake()
    {
        // Initialize references and calculate attack damage
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<HellephantHealth>();
        anim = GetComponent<Animator>();
        enemyManager = GameObject.FindGameObjectWithTag("EnemyManager");
        EMS = enemyManager.GetComponent<HellephantManager>();

        rawAttackDamage = 10 + EMS.spawnAmount * 3.8f;
        rawAttackDamage = rawAttackDamage * 10;
        attackDamage = Convert.ToInt32(Mathf.Round(rawAttackDamage));
    }

    void OnTriggerEnter(Collider other)
    {
        // Detect when the player enters attack range
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Detect when the player leaves attack range
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    void Update()
    {
        // Handle attack logic
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack();
        }

        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("PlayerDead");
        }
    }

    void Attack()
    {
        // Perform an attack on the player
        timer = 0f;

        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
