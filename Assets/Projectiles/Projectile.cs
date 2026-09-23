using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] private float lifetime = 1f;
    [SerializeField] private float speed = 1f;

    private Vector2 spawnPoint;
    private float elapsedTime;

    public float Lifetime
    {
        get => lifetime;
        set => lifetime = Mathf.Max(0f, value);
    }

    public float Speed
    {
        get => speed;
        set => speed = Mathf.Max(0f, value);
    }

    protected virtual void Start()
    {
        spawnPoint = transform.position;
    }

    protected virtual void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= Lifetime)
        {
            Destroy(gameObject);
            return;
        }

        transform.position = CalculateMovement(elapsedTime, spawnPoint);
    }

    public virtual void Initialize(float projectileSpeed, float projectileLifetime)
    {
        Speed = projectileSpeed;
        Lifetime = projectileLifetime;
    }

    protected virtual Vector2 CalculateMovement(float timer, Vector2 startPosition)
    {
        Vector2 direction = transform.right;
        float x = startPosition.x + timer * Speed * direction.x;
        float y = startPosition.y + timer * Speed * direction.y;
        return new Vector2(x, y);
    }
}

public class StandardProjectile : Projectile
{
    // Inherited projectile behavior: straight movement with no override.
}

public class WavyProjectile : Projectile
{
    [SerializeField] private float waveAmplitude = 0.25f;
    [SerializeField] private float waveFrequency = 8f;

    protected override Vector2 CalculateMovement(float timer, Vector2 startPosition)
    {
        Vector2 basePosition = base.CalculateMovement(timer, startPosition);
        float waveOffset = Mathf.Sin(timer * waveFrequency) * waveAmplitude;
        return new Vector2(basePosition.x, basePosition.y + waveOffset);
    }
}
