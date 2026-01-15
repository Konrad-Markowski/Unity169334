using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    
    private float lastHitTime;
    private float damageCooldown = 0.1f; 

    void Start()
    {
        currentHealth = maxHealth;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public void TakeDamage(int damage)
    {
        if (Time.time < lastHitTime + damageCooldown) return;

        currentHealth -= damage;
        lastHitTime = Time.time;

        Debug.Log($"Trafiono {gameObject.name}! HP: {currentHealth}");

        if (gameObject.CompareTag("Player"))
        {
            PointTracker tracker = GetComponent<PointTracker>();
            if (tracker != null)
            {
                tracker.combo = 1;
            }
        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}