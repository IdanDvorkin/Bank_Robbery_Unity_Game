using UnityEngine;

public class PlayerShootingRaycast : MonoBehaviour
{
    public GameObject gun; // Gun must have LineRenderer component.
    public GameObject aCamera;
    public LayerMask hitLayers; // Set this in the Inspector to the layers you want the bullets to hit.

    public int bulletDamage = 20;
    public float timeBetweenShots = 0.5f;
    public float bulletSpeed = 100f;

    private LineRenderer line;
    private AudioSource gunSound;

    private void Start()
    {
        line = gun.GetComponent<LineRenderer>();
        gunSound = gun.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (!gun.activeSelf)
            return;

        RaycastHit hit;
        if (Physics.Raycast(aCamera.transform.position, aCamera.transform.forward, out hit, Mathf.Infinity, hitLayers))
        {
            GameObject target = hit.collider.gameObject;

            // Draw the fire line.
            DrawFireLine(aCamera.transform.position, hit.point);

            if (target.CompareTag("Enemy"))
            {
                // Apply damage to the enemy.
                EnemyHealth enemyHealth = target.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(bulletDamage);
                }
            }
        }
        else
        {
            // If the raycast doesn't hit anything, draw the fire line to a distant point.
            DrawFireLine(aCamera.transform.position, aCamera.transform.position + aCamera.transform.forward * 100f);
        }

        gunSound.Play();
    }

    private void DrawFireLine(Vector3 start, Vector3 end)
    {
        line.enabled = true;
        line.SetPosition(0, start);
        line.SetPosition(1, end);
        Invoke("DisableFireLine", 0.1f);
    }

    private void DisableFireLine()
    {
        line.enabled = false;
    }
}
