using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;
    public float maxDistance = 100f; // The maximum distance the bullet can travel.
    public LayerMask hitLayers; // Set this in the Inspector to the layers you want the bullet to hit.

    private Vector3 startingPosition;

    private void Start()
    {
        startingPosition = transform.position;
    }

    public Vector3 StartingPosition
    {
        get { return startingPosition; }
    }

    private void Update()
    {
        // Check for raycast hits.
        RaycastDetection();

        // Check if the bullet has traveled its maximum distance, and destroy it if so.
        float traveledDistance = Vector3.Distance(startingPosition, transform.position);
        if (traveledDistance >= maxDistance)
        {
            DestroyBullet();
        }
    }

    private void RaycastDetection()
    {
        // Cast a ray forward from the bullet's position.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Time.deltaTime * maxDistance, hitLayers))
        {
            // Check if the raycast hit an object on the hitLayers.
            GameObject target = hit.collider.gameObject;

            if (target.CompareTag("Player"))
            {
                // Apply damage to the player.
                PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damage);
                }
            }
            else if (target.CompareTag("Enemy"))
            {
                // Apply damage to the enemy.
                EnemyHealth enemyHealth = target.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damage);
                }
            }

            // Destroy the bullet after hitting any object.
            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        // Destroy the bullet GameObject.
        Destroy(gameObject);
    }
}
