﻿using UnityEngine;

public class ZomBunnyHealth : MonoBehaviour
{
    // Variables
    public int startingHealth = 100; // Initial health of the ZomBunny
    public int currentHealth; // Current health of the ZomBunny
    public float sinkSpeed = 2.5f; // Speed at which the ZomBunny sinks upon death
    public int scoreValue = 10; // Score awarded upon ZomBunny's death
    public AudioClip deathClip; // Audio clip played on death

    Animator anim; // Animator component for death animations
    AudioSource enemyAudio; // Audio source for playing sounds
    ParticleSystem hitParticles; // Particle system for hit effects
    CapsuleCollider capsuleCollider; // Collider component
    GameObject EM; // Reference to the Enemy Manager
    ZomBunnyManager EMS; // Reference to the ZomBunny Manager script
    bool isDead; // Whether the ZomBunny is dead
    bool isSinking; // Whether the ZomBunny is sinking

    void Awake()
    {
        // Initialize components and variables
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        EM = GameObject.FindWithTag("EnemyManager");
        EMS = EM.GetComponent<ZomBunnyManager>();
        currentHealth = startingHealth + EMS.spawnAmount * 5;
    }

    void Update()
    {
        // Handle sinking behavior
        if (isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        // Apply damage and handle death logic
        if (isDead) return;

        enemyAudio.Play();
        currentHealth -= amount;
        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        // Handle death logic
        isDead = true;
        capsuleCollider.isTrigger = true;
        anim.SetTrigger("Dead");
        enemyAudio.clip = deathClip;
        enemyAudio.Play();
    }

    public void StartSinking()
    {
        // Begin sinking and award score
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        ScoreManager.score += scoreValue;
        Destroy(gameObject, 2f);
    }
}
