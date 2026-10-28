using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
    [SerializeField] private GameObject loseText;

    [SerializeField] private bool invincible;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (invincible) return;

        if (other.CompareTag("Enemy Projectile"))
        {
            loseText.SetActive(true);
            transform.parent.gameObject.SetActive(false);

        }
    }

}
