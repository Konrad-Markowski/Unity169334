using UnityEngine;
using UnityEngine.InputSystem;

public class ShootShell : MonoBehaviour
{
    public Transform shellSpawnPoint;
    public GameObject shellPrefab;
    public float shellSpeed = 20f;
    
    [Header("Dźwięki")]
    public AudioSource audioSource;
    public AudioClip fireSound;
    
    [Header("Ustawienia Strzału")]
    public float fireRate = 0.5f;
    private float nextFireTime;

    void OnShoot(InputValue value)
    {
        if (value.isPressed && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (shellPrefab != null && shellSpawnPoint != null)
        {
            GameObject shell = Instantiate(shellPrefab, shellSpawnPoint.position, shellSpawnPoint.rotation);
            
            Shell shellScript = shell.GetComponent<Shell>();
            if (shellScript != null)
            {
                shellScript.isPlayerShell = true;
            }

            Rigidbody rb = shell.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = shell.transform.forward * shellSpeed;
            }

            if (audioSource != null && fireSound != null)
            {
                audioSource.PlayOneShot(fireSound);
            }
        }
    }
}