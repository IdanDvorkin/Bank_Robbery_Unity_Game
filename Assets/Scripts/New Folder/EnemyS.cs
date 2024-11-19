using UnityEngine;
using UnityEngine.Events;
using System.Collections;
public class EnemyS : MonoBehaviour
{
    public float timeBetweenShots = 1f;
    public int raycastDamage = 10;
    public float raycastRange = 50f;
    public float raycastDuration = 0.5f;
    public Transform lineStartPosition; // The starting position of the line.
    public GameObject gunSoundOBJ;
    private Transform player;
    private bool canShoot = true;
    private bool isWounded = false;
    private bool isDead = false;

    public UnityEvent OnEnemyWounded;
    public UnityEvent OnEnemyDead;
    AudioSource gunSound;
    private LineRenderer lineRenderer; // Reference to the LineRenderer component.

    private void Start()
    {
        gunSound= gunSoundOBJ.GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lineRenderer = GetComponent<LineRenderer>(); // Get the LineRenderer component attached to the same GameObject.
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (canShoot && player != null && !isWounded && !isDead&&distance<=100)
        {
            Vector3 directionToPlayer = player.position - transform.position;
            transform.forward = directionToPlayer.normalized;
            gunSound.Play();
            Shoot();
        }
    }

    private void Shoot()
    {
        if (player == null)
            return;

        Ray ray = new Ray(lineStartPosition.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, raycastRange))
        {
            if (hit.collider.CompareTag("Player"))
            {
                PlayerHealth playerHealth = hit.collider.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(raycastDamage);
                }
            }
        }

        // Draw the raycast using LineRenderer.
        StartCoroutine(DrawRaycast(ray, raycastDuration));
        canShoot = false;
        Invoke("EnableShoot", timeBetweenShots);
    }

    private void EnableShoot()
    {
        canShoot = true;
    }

    private IEnumerator DrawRaycast(Ray ray, float duration)
    {
        // Set the starting position of the line.
        lineRenderer.SetPosition(0, lineStartPosition.position);

        // If the raycast hits something, animate the line to the hit point.
        if (Physics.Raycast(ray, out RaycastHit hit, raycastRange))
        {
            lineRenderer.SetPosition(1, hit.point);
        }
        // If the raycast doesn't hit anything, animate the line to the maximum range.
        else
        {
            lineRenderer.SetPosition(1, lineStartPosition.position + transform.forward * raycastRange);
        }

        // Show the line.
        lineRenderer.enabled = true;

        // Wait for the specified duration.
        yield return new WaitForSeconds(duration);

        // Hide the line.
        lineRenderer.enabled = false;
    }

    public void SetWoundedState(bool wounded)
    {
        isWounded = wounded;
    }

    public void SetDeadState(bool dead)
    {
        isDead = dead;
    }
}
