using UnityEngine;

public class Shell : MonoBehaviour
{
    public float life = 5f;
    
    public bool isPlayerShell = false; 

    void Start()
    {
        Destroy(gameObject, life);
    }

    private void OnTriggerEnter(Collider other) 
    {
        Health health = other.GetComponentInParent<Health>();
        GameObject player = GameObject.Find("Player");

        if (health != null)
        {
            health.TakeDamage(1);

            if (other.CompareTag("Enemy") && player != null)
            {

                PointTracker tracker = player.GetComponent<PointTracker>();
                if (tracker != null)
                {
                    tracker.AddPoints();
                    tracker.combo++;
                }
            }
        }
        else 
        {
            if (isPlayerShell && player != null)
            {
                PointTracker tracker = player.GetComponent<PointTracker>();
                if (tracker != null)
                {
                    tracker.combo = 1;
                }
            }
        }

        Destroy(gameObject);
    }
}