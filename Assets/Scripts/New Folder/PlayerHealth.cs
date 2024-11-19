using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Text healthBarText; // Reference to the UI Text for the health bar.

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }

        UpdateUI();
    }

    private void Die()
    {
        // Implement the player's death behavior here if needed.
        // For example, show a game over screen or respawn the player.
        // You can also reload the current scene or perform any other actions as required.
    }

    private void UpdateUI()
    {
        // Update the UI health bar text with the current health value.
        healthBarText.text = "Health: " + currentHealth.ToString();
    }
}
