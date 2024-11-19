using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth: MonoBehaviour
{
    public int maxHealth = 50;
    public GameObject enemy;
    public int currentHealth;
    AudioSource scream;

    private void Start()
    {
        scream = enemy.GetComponent<AudioSource>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
        else
            Hit();
    }
    private void Hit()
    {
        NavMeshAgent agent = enemy.gameObject.GetComponent<NavMeshAgent>();
        Animator a = enemy.GetComponent<Animator>();
        a.SetInteger("Status", 3);
        scream.Play();
        a.SetInteger("Status", 0);
    }

    private void Die()
    {
        // Add any death effects or logic here.
        NavMeshAgent agent = enemy.gameObject.GetComponent<NavMeshAgent>();
        agent.enabled = false;
        Animator a = enemy.GetComponent<Animator>();
        a.SetInteger("Status", 2);
        scream.Play();
    }
}
