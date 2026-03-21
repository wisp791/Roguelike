using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static float damage = 10f;
    public static float lifeTime = 3f;
    public static float speed = 10f;
    private static bool sizeUpgrade = false;
    public float spawnTime;
    public static BulletMethod method;
    private Rigidbody2D rb;
    public BulletData bulletData;
    public AudioClip hit;
    public WeaponData weaponData;
    public Transform playerTransform;
    public AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake() => spawnTime = Time.time;
    
    void Start()
    {
        damage = weaponData.damage;
        playerTransform = FindFirstObjectByType<PlayerStats>().transform;
        rb = GetComponent<Rigidbody2D>();
        if (!sizeUpgrade)
        {
            transform.localScale = new Vector3(0.23f, 0.23f, 0.23f);
        }
        else
        {
            transform.localScale = new Vector3(0.33f, 0.33f, 0.33f);
        }
        if (rb != null)
        {
            rb.velocity = transform.right * speed;
        }
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        bulletData.bulletMethod.Method(this);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            audioSource.PlayOneShot(hit);
        }
        BossSlime boss = other.GetComponent<BossSlime>();
        if (boss != null)
        {
            boss.BossDamage(damage);
            audioSource.PlayOneShot(hit);
        }
    }

    public void DamageIncrease()
    {
        damage += 5f;
    }

    public void sizeIncrease()
    {
        sizeUpgrade = true;
    }

    public void SetForwardMethod()
    {
        method = new ForwardBulletMethod();
    }

    public void SetSpinMethod()
    {
        method = new SpinBulletMethod();
    }

    public void SetSpiralMethod()
    {
        method = new SpiralBulletMethod();
    }
}
