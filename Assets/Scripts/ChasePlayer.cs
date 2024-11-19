using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float detectionDistance = 10f; // Distance at which the enemy detects the player
    public float chaseSpeed = 3f; // Speed at which the enemy chases the player
    private static bool chaseBackwards = false; // Static variable to determine if enemies should chase backwards

    private void Update()
    {
        // Check if the player is within the detection distance
        if (Vector3.Distance(transform.position, player.position) <= detectionDistance)
        {
            // Calculate the angle between the enemy's forward direction and the direction to the player
            Vector3 directionToPlayer = player.position - transform.position;
            float angle = Vector3.Angle(transform.forward, directionToPlayer);

            // Check if the player is in front of or within 90 degrees to the side of the enemy
            if (angle <= 90f || chaseBackwards)
            {
                // Look at the player (optional)
                transform.LookAt(player);

                // Move towards the player
                transform.position += transform.forward * chaseSpeed * Time.deltaTime;
            }
        }
    }

    // Call this static method to enable or disable chasing backwards for all enemies
    public static void setChaseBackwards(bool shouldChaseBackwards)
    {
        chaseBackwards = shouldChaseBackwards;
    }
}