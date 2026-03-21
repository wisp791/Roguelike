using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float cooldown = 1f;
    public int count = 1;
    public float attackDelay = 0.1f;

    private WeaponData weaponData;

    public GameObject bullet;
    private Transform playerTransform;
    public Camera mainCamera;
    public PlayerStats PS;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = GameObject.FindFirstObjectByType<Camera>();
        PS = GameObject.FindFirstObjectByType<PlayerStats>();
        playerTransform = PS.gameObject.transform;
        weaponData = gameObject.GetComponent<Weapon>().weaponData;
        bullet = weaponData.bulletPrefab;

        cooldown = weaponData.cooldown;
        count = weaponData.bulletCount;
        attackDelay = weaponData.bulletDelay;
        StartCoroutine(StartShooting());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartShooting()
    {
        while (true)
        {
            // 1. get mouse position in world space
            Vector3 mouseScreenPosition = Input.mousePosition;
            Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);
            mouseWorldPosition.z = 0;

            // 2. define spawn location
            Vector3 spawnPosition = playerTransform.position;

            // 3. calculate direction vector
            Vector3 direction = mouseWorldPosition - spawnPosition;

            // 4. calculate rotation angle
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            //5. create rotation quaternion
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);
            
            spawnPosition = spawnPosition + (targetRotation * spawnPosition).normalized * -0.1f;

            if (PS.level < 8)
            {
                StartCoroutine(SpawnBullet(attackDelay, spawnPosition, targetRotation));
            }
            else
            {
                Instantiate(bullet, spawnPosition, targetRotation);
                Instantiate(bullet, spawnPosition, targetRotation * Quaternion.Euler(0, 0, 180f));
            }
            yield return new WaitForSeconds(cooldown);
        }

        IEnumerator SpawnBullet(float amount, Vector3 spawnPosition, Quaternion targetRotation)
        {
            yield return new WaitForSeconds(amount);
            GameObject instance = Instantiate(bullet, spawnPosition, targetRotation);
            Bullet instanceBullet = instance.GetComponent<Bullet>();
            //instanceBullet.SetDamageStat(playerStats.ATK);
            instanceBullet.weaponData = weaponData;
        }

    }

    public void FireRateIncrease()
    {
        cooldown -= 0.1f;
        if (cooldown <= 0)
        {
            cooldown = 0.1f;
        }
    }
}
