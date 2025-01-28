using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20; // Damage dealt per shot
    public float timeBetweenBullets = 0.15f; // Time delay between shots
    public float range = 100f; // Shooting range

    float timer; // Tracks time since last shot
    Ray shootRay = new Ray(); // Ray for shooting logic
    RaycastHit shootHit; // Stores information about what was hit
    int shootableMask; // Layer mask for shootable objects
    bool isGatling; // Flag for Gatling Gun mode
    bool isShotgun; // Flag for Shotgun mode
    ParticleSystem gunParticles; // Visual effects for shooting
    LineRenderer gunLine; // Line renderer for bullet trails
    AudioSource gunAudio; // Audio source for shooting sounds
    Light gunLight; // Light effect for shooting
    float effectsDisplayTime = 0.2f; // Duration of visual effects
    float gatlingGunTimer; // Timer for Gatling Gun mode
    float shotgunTimer; // Timer for Shotgun mode

    void Start()
    {
        // Initialize timers and shooting parameters
        gatlingGunTimer = 0;
        shotgunTimer = 0;
        isGatling = false;
        isShotgun = false;
        timeBetweenBullets = 0.15f;
        damagePerShot = 20;
    }

    void Awake()
    {
        // Set up component references and layer masks
        shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
    }

    void Update()
    {
        timer += Time.deltaTime; // Update the timer

        // Handle shooting input
        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shoot();
        }

        // Disable effects if their duration has passed
        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects();
        }

        // Update Gatling Gun mode
        if (isGatling)
        {
            gatlingGunTimer += Time.deltaTime;
            if (gatlingGunTimer >= 8)
            {
                gatlingGunTimer = 0;
                isGatling = false;
                timeBetweenBullets = 0.15f;
            }
        }

        // Update Shotgun mode
        if (isShotgun)
        {
            shotgunTimer += Time.deltaTime;
            if (shotgunTimer >= 12)
            {
                shotgunTimer = 0;
                isShotgun = false;
                timeBetweenBullets = 0.15f;
                damagePerShot = 20;
            }
        }
    }

    public void DisableEffects()
    {
        // Turn off visual effects
        gunLine.enabled = false;
        gunLight.enabled = false;
    }

    void Shoot()
    {
        timer = 0f; // Reset timer for next shot

        gunAudio.Play(); // Play shooting sound
        gunLight.enabled = true; // Enable shooting light
        gunParticles.Stop(); // Restart particle effects
        gunParticles.Play();

        gunLine.enabled = true; // Enable bullet trail
        gunLine.SetPosition(0, transform.position);

        shootRay.origin = transform.position; // Set ray origin to player position
        shootRay.direction = transform.forward; // Set ray direction forward

        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            // Check if an enemy was hit and apply damage
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damagePerShot, shootHit.point);
            }
            gunLine.SetPosition(1, shootHit.point);

            ZomBunnyHealth zomHealth = shootHit.collider.GetComponent<ZomBunnyHealth>();
            if (zomHealth != null)
            {
                zomHealth.TakeDamage(damagePerShot, shootHit.point);
            }
            gunLine.SetPosition(1, shootHit.point);

            ZomBearHealth bearHealth = shootHit.collider.GetComponent<ZomBearHealth>();
            if (bearHealth != null)
            {
                bearHealth.TakeDamage(damagePerShot, shootHit.point);
            }
            gunLine.SetPosition(1, shootHit.point);

            HellephantHealth hellHealth = shootHit.collider.GetComponent<HellephantHealth>();
            if (hellHealth != null)
            {
                hellHealth.TakeDamage(damagePerShot, shootHit.point);
            }
            gunLine.SetPosition(1, shootHit.point);
        }
        else
        {
            // Extend bullet trail to max range if nothing is hit
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }

    public void GatlingGun()
    {
        // Activate Gatling Gun mode
        timeBetweenBullets = 0.05f;
        gatlingGunTimer = 0;
        isGatling = true;
    }

    public void ShotGun()
    {
        // Activate Shotgun mode
        damagePerShot = 100;
        timeBetweenBullets = 0.5f;
        isShotgun = true;
        shotgunTimer = 0;
    }
}
