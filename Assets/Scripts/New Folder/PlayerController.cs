using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Image AmmoCircle;
    public int maxAmmo = 30;
    public int maxMagazines = 5;
    public float timeBetweenShots = 0.5f;
    public float reloadTime = 1.5f;
    public Text healthText;
    public Text ammoText;
    public Text magazinesText;
    public int bulletDamage = 20;

    private int currentAmmo;
    private int currentMagazines;
    private bool canShoot = true;
    private bool isReloading = false;
    private PlayerHealth playerHealth;
    public GameObject reloadSoundOBJ;
    AudioSource reloadSound;

    void Ammo()
    {
        AmmoCircle.fillAmount = (float)currentAmmo / maxAmmo;
    }

    private void Start()
    {
        reloadSound=reloadSoundOBJ.GetComponent<AudioSource>();
        playerHealth = GetComponent<PlayerHealth>(); // Get the PlayerHealth component on start.

        currentAmmo = maxAmmo;
        currentMagazines = maxMagazines;
        Ammo();

        UpdateUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot && currentAmmo > 0 && !isReloading)
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R) && !isReloading)
        {
            Reload();
        }
    }

    private void Shoot()
    {
        currentAmmo--;
        Ammo();
        UpdateUI();

    }

    private void Reload()
    {
        if (currentMagazines > 0 && currentAmmo < maxAmmo)
        {
            reloadSound.Play();
            isReloading = true;
            Invoke("FinishReload", reloadTime);
        }
    }

    private void FinishReload()
    {
        int bulletsNeeded = maxAmmo - currentAmmo;
        int bulletsToReload = Mathf.Min(bulletsNeeded, currentMagazines * maxAmmo);

        currentAmmo += bulletsToReload;
        Ammo();
        currentMagazines -= Mathf.CeilToInt((float)bulletsToReload / maxAmmo);

        isReloading = false;
        UpdateUI();
    }

    private void UpdateUI()
    {
        healthText.text = playerHealth.currentHealth.ToString();
        ammoText.text = currentAmmo.ToString() + " / " + maxAmmo.ToString();
        magazinesText.text =  currentMagazines.ToString();
    }
}
