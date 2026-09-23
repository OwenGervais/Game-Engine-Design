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
        elapsedTime += 1;

        if (elapsedTime >= Lifetime * 60) // lifetime is based on seconds
        {
            Destroy(gameObject);
            return;
        }

        transform.position = CalculateMovement(elapsedTime, spawnPoint);
    }

    public virtual void Initialize(float projectileSpeed, float projectileLifetime)
    {
        Speed = projectileSpeed / 60;
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