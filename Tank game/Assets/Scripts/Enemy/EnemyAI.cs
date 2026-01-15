using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;

    [Header("Zasięgi")]
    public float detectionRange = 25f;
    public float lostRange = 40f;
    public float shootingRange = 15f; 

    [Header("Stan")]
    private bool isChasing = false;

    [Header("Walka")]
    public GameObject shellPrefab;
    public Transform shootPoint;
    public float fireRate = 2f;
    public float shellSpeed = 15f;
    private float nextFireTime;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null) player = playerObj.transform;

        agent.stoppingDistance = shootingRange - 2f;
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (!isChasing)
        {
            if (distanceToPlayer <= detectionRange)
            {
                isChasing = true;
                Debug.Log("Wróg: Wykryto gracza! Rozpoczynam pościg.");
            }
        }
        else
        {
            if (distanceToPlayer > lostRange)
            {
                isChasing = false;
                agent.ResetPath();
                Debug.Log("Wróg: Gracz zgubiony.");
            }
            else
            {
                agent.SetDestination(player.position);
                RotateTowardsPlayer();

                if (distanceToPlayer <= shootingRange && Time.time > nextFireTime)
                {
                    Shoot();
                    nextFireTime = Time.time + fireRate;
                }
            }
        }
    }

    private void RotateTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0;
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }

    void Shoot()
    {
        if (shellPrefab != null && shootPoint != null)
        {
            GameObject shell = Instantiate(shellPrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody rb = shell.GetComponent<Rigidbody>();
            if (rb != null) rb.linearVelocity = shootPoint.forward * shellSpeed;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lostRange);
    }
}