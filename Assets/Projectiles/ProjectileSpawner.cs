using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    private enum SpawnerType
    {
        Straight,
        Spin
    }

    [Header("Projectile Settings")]
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private float projectileLife = 1f;
    [SerializeField] private float speed = 1f;

    [Header("Spawner Settings")]
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float firingRate = 1f;
    [SerializeField] private float spinSpeed = 1f;
    [SerializeField] private bool reverse = true;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (spawnerType == SpawnerType.Spin)
        {
            float rotationDirection = reverse ? -1f : 1f;
            transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + spinSpeed * rotationDirection * Time.deltaTime);
        }

        if (timer >= firingRate)
        {
            Fire();
            timer = 0f;
        }
    }

    private void Fire()
    {
        if (projectilePrefab == null)
        {
            return;
        }

        Projectile spawnedProjectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        spawnedProjectile.Initialize(speed, projectileLife);
    }
}
