using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
    [SerializeField] private GameObject loseText;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy Projectile"))
        {
            loseText.SetActive(true);
            transform.parent.gameObject.SetActive(false);

        }
    }

}
