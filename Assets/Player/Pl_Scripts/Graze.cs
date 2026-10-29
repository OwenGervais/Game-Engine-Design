using Patterns.Creational.Factory.Usage;
using UnityEngine;

public class Graze : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy Projectile"))
        {
            GameController.Instance.CurrentScore += 1;
        }
    }
}