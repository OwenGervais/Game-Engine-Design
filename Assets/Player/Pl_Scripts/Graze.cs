using UnityEngine;

public class Graze : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy Projectile"))
        {
            ScoreManager.Instance.AddScore(1);
        }
    }
}