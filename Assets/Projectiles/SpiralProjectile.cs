using UnityEngine;

public class SpiralProjectile : Projectile
{
    [SerializeField] private float rotationSpeed = 30f;

    protected override Vector2 CalculateMovement(float timer, Vector2 startPosition)
    {
        transform.Rotate(0f, 0f, rotationSpeed / 60f);
        return startPosition + (Vector2)transform.right * (timer * Speed);
    }
}